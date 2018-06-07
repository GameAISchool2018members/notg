using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handle everything related to controlling the character. Interact with both the Character (visual, animation) and CharacterCollider
/// </summary>
public class CharacterInputController : InputController
{
    static int s_DeadHash = Animator.StringToHash("Dead");
    static int s_RunStartHash = Animator.StringToHash("runStart");
    static int s_MovingHash = Animator.StringToHash("Moving");
    static int s_JumpingHash = Animator.StringToHash("Jumping");
    static int s_JumpingSpeedHash = Animator.StringToHash("JumpSpeed");
    static int s_SlidingHash = Animator.StringToHash("Sliding");

    public GameObject blobShadow;
    public RayPerception rayPerception;
    public float laneChangeSpeed = 1.0f;

    public Consumable inventory;

    public bool isJumping { get { return m_Jumping; } }
    public bool isSliding { get { return m_Sliding; } }

    [Header("Controls")]
    public bool isVerticalMovementEnabled = false;

    public float jumpLength = 2.0f;     // Distance jumped
    public float jumpHeight = 1.2f;

    public float slideLength = 2.0f;

    [Header("Sounds")]
    public AudioClip slideSound;

    protected int m_ObstacleLayer;


    protected float m_JumpStart;
    protected bool m_Jumping;

    protected bool m_Sliding;
    protected float m_SlideStart;

    protected AudioSource m_Audio;

    protected int m_CurrentLane = k_StartingLane;
    protected Vector3 m_TargetPosition = Vector3.zero;

    protected readonly Vector3 k_StartingPosition = Vector3.forward * 2f;

    protected const int k_StartingLane = 1;
    protected const float k_GroundingSpeed = 80f;
    protected const float k_ShadowRaycastDistance = 100f;
    protected const float k_ShadowGroundOffset = 0.01f;
    protected const float k_TrackSpeedToJumpAnimSpeedRatio = 0.6f;
    protected const float k_TrackSpeedToSlideAnimSpeedRatio = 0.9f;
    public Dictionary<string, float> obstacleMapping;

    protected void Awake()

    {
        m_Premium = 0;
        m_CurrentLife = 0;
        m_Sliding = false;
        m_SlideStart = 0.0f;
        obstacleMapping = new Dictionary<string, float>();
        obstacleMapping.Add("Pickup(Clone)", 0);
        obstacleMapping.Add("ObstacleBin(Clone)", 1);
        obstacleMapping.Add("ObstacleWheelyBin(Clone)", 1);
        obstacleMapping.Add("ObstacleRoadworksCone(Clone)", 1);
    }

#if !UNITY_STANDALONE
    protected Vector2 m_StartingTouch;
	protected bool m_IsSwiping = false;
#endif

    public void Init()
    {
        transform.position = k_StartingPosition;
        m_TargetPosition = Vector3.zero;

        m_CurrentLane = k_StartingLane;
        characterCollider.transform.localPosition = Vector3.zero;

        currentLife = maxLife;

        m_Audio = GetComponent<AudioSource>();

        m_ObstacleLayer = 1 << LayerMask.NameToLayer("Obstacle");
        m_Jumping = false;
        m_Sliding = false;
    }

    // Called at the beginning of a run or rerun
    public void Begin()
    {
        character.animator.SetBool(s_DeadHash, false);

        characterCollider.Init();

        m_ActiveConsumables.Clear();
    }

    public void End()
    {
        CleanConsumable();
    }

    public void CleanConsumable()
    {
        for (int i = 0; i < m_ActiveConsumables.Count; ++i)
        {
            m_ActiveConsumables[i].Ended(this);
            Destroy(m_ActiveConsumables[i].gameObject);
        }

        m_ActiveConsumables.Clear();
    }

    protected void FixedUpdate()
    {
        Vector3 verticalTargetPosition = m_TargetPosition;

        if (m_Sliding)
        {
            // Slide time isn't constant but the slide length is (even if slightly modified by speed, to slide slightly further when faster).
            // This is for gameplay reason, we don't want the character to drasticly slide farther when at max speed.
            float correctSlideLength = slideLength * (1.0f + trackManager.AICharSpeedRatio);
            float ratio = (trackManager.worldDistance - m_SlideStart) / correctSlideLength;
            if (ratio >= 1.0f)
            {
                // We slid to (or past) the required length, go back to running
                StopSliding();
            }
        }

        if (m_Jumping)
        {
            if (trackManager.isAICharMoving)
            {
                // Same as with the sliding, we want a fixed jump LENGTH not fixed jump TIME. Also, just as with sliding,
                // we slightly modify length with speed to make it more playable.
                float correctJumpLength = jumpLength * (1.0f + trackManager.AICharSpeedRatio);
                float ratio = (trackManager.worldDistance - m_JumpStart) / correctJumpLength;
                if (ratio >= 1.0f)
                {
                    m_Jumping = false;
                    character.animator.SetBool(s_JumpingHash, false);
                }
                else
                {
                    verticalTargetPosition.y = Mathf.Sin(ratio * Mathf.PI) * jumpHeight;
                }
            }
            else if (!AudioListener.pause)//use AudioListener.pause as it is an easily accessible singleton & it is set when the app is in pause too
            {
                verticalTargetPosition.y = Mathf.MoveTowards(verticalTargetPosition.y, 0, k_GroundingSpeed * Time.deltaTime);
                if (Mathf.Approximately(verticalTargetPosition.y, 0f))
                {
                    character.animator.SetBool(s_JumpingHash, false);
                    m_Jumping = false;
                }
            }

        }

        characterCollider.transform.localPosition = Vector3.MoveTowards(characterCollider.transform.localPosition, verticalTargetPosition, laneChangeSpeed * Time.fixedDeltaTime);
    }

    protected void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // Use key input in editor or standalone
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    ChangeLane(-1);
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    ChangeLane(1);
        //}
        //else if (Input.GetKeyDown(KeyCode.UpArrow) && isVerticalMovementEnabled)
        //{
        //    Jump();
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow) && isVerticalMovementEnabled)
        //{
        //    if (!m_Sliding)
        //        Slide();
        //}
#else
        // Use touch input on mobile
        if (Input.touchCount == 1)
        {
			if(m_IsSwiping)
			{
				Vector2 diff = Input.GetTouch(0).position - m_StartingTouch;

				// Put difference in Screen ratio, but using only width, so the ratio is the same on both
                // axes (otherwise we would have to swipe more vertically...)
				diff = new Vector2(diff.x/Screen.width, diff.y/Screen.width);

				if(diff.magnitude > 0.01f) //we set the swip distance to trigger movement to 1% of the screen width
				{
					if(Mathf.Abs(diff.y) > Mathf.Abs(diff.x))
					{
						if(diff.y < 0)
						{
							Slide();
						}
						else
						{
							Jump();
						}
					}
					else
					{
						if(diff.x < 0)
						{
							ChangeLane(-1);
						}
						else
						{
							ChangeLane(1);
						}
					}
						
					m_IsSwiping = false;
				}
            }

        	// Input check is AFTER the swip test, that way if TouchPhase.Ended happen a single frame after the Began Phase
			// a swipe can still be registered (otherwise, m_IsSwiping will be set to false and the test wouldn't happen for that began-Ended pair)
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				m_StartingTouch = Input.GetTouch(0).position;
				m_IsSwiping = true;
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				m_IsSwiping = false;
			}
        }
#endif


        // Put blob shadow under the character.
        RaycastHit hit;
        if (Physics.Raycast(characterCollider.transform.position + Vector3.up, Vector3.down, out hit, k_ShadowRaycastDistance, m_ObstacleLayer))
        {
            blobShadow.transform.position = hit.point + Vector3.up * k_ShadowGroundOffset;
        }
        else
        {
            Vector3 shadowPosition = characterCollider.transform.position;
            shadowPosition.y = k_ShadowGroundOffset;
            blobShadow.transform.position = shadowPosition;
        }
    }

    public void Jump()
    {
        if (!m_Jumping)
        {
            if (m_Sliding)
                StopSliding();

            float correctJumpLength = jumpLength * (1.0f + trackManager.AICharSpeedRatio);
            m_JumpStart = trackManager.worldDistance;
            float animSpeed = k_TrackSpeedToJumpAnimSpeedRatio * (trackManager.AICharSpeed / correctJumpLength);

            character.animator.SetFloat(s_JumpingSpeedHash, animSpeed);
            character.animator.SetBool(s_JumpingHash, true);
            m_Audio.PlayOneShot(character.jumpSound);
            m_Jumping = true;
        }
    }

    public void Slide()
    {
        if (!m_Sliding && !m_Jumping)
        {
            float correctSlideLength = slideLength * (1.0f + trackManager.AICharSpeedRatio);
            m_SlideStart = trackManager.worldDistance;
            float animSpeed = k_TrackSpeedToJumpAnimSpeedRatio * (trackManager.AICharSpeed / correctSlideLength);

            character.animator.SetFloat(s_JumpingSpeedHash, animSpeed);
            character.animator.SetBool(s_SlidingHash, true);
            m_Audio.PlayOneShot(slideSound);
            m_Sliding = true;

            characterCollider.Slide(true);
        }
    }

    public void StopSliding()
    {
        if (m_Sliding)
        {
            character.animator.SetBool(s_SlidingHash, false);
            m_Sliding = false;

            characterCollider.Slide(false);
        }
    }

    public void ChangeLaneDirectly(int lane)
    {
        if (!trackManager.isAICharMoving)
            return;

        if (lane < 0 || lane > 2)
            // Ignore, we are on the borders.
            return;

        if (lane == m_CurrentLane)
            return;
        
        m_CurrentLane = lane;

        m_TargetPosition = new Vector3((m_CurrentLane - 1) * trackManager.laneOffset, 0, 0);
    }

    public void ChangeLane(int direction)
    {
        if (!trackManager.isAICharMoving)
            return;
        
        int targetLane = m_CurrentLane + direction;

        if (targetLane < 0 || targetLane > 2)
            // Ignore, we are on the borders.
            return;

        m_CurrentLane = targetLane;

        m_TargetPosition = new Vector3((m_CurrentLane - 1) * trackManager.laneOffset, 0, 0);
    }

    public void UseInventory()
    {
        if (inventory != null && inventory.CanBeUsed(this))
        {
            UseConsumable(inventory);
            inventory = null;
        }
    }


    #region AI stuff

    private int lastMeterPassed;

    public bool FarPerceptionsEnabled = false;
    public float FarDistanceOffset = 6f;
    public float LowPerceptionHeightOffset = 0.1f;
    public float HighPerceptionHeightOffset = 1.2f;
    public float RayLength = 30f;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
    }

    public override void CollectObservations()
    {
        AddVectorObs(characterCollider.transform.localPosition.x);

        var angles = new float[] { 0f, 30f, 60f, 75f, 85f, 90f, 95f, 105f, 120f, 150f, 180f };

        var fishTags = new string[] { "fish" };
        var obstacleTags = new string[] { "obstacle" };

        var nearOffsetLow = new Vector3(0f, LowPerceptionHeightOffset, 0f);
        var nearOffsetHigh = new Vector3(0f, HighPerceptionHeightOffset, 0f);
        List<float> lowPerceptionsNear = rayPerception.Perceive(RayLength, angles, fishTags, nearOffsetLow, Vector3.zero, Color.black);
        List<float> highPerceptionsNear = rayPerception.Perceive(RayLength, angles, obstacleTags, nearOffsetHigh, Vector3.zero, Color.blue);

        AddVectorObs(lowPerceptionsNear);
        AddVectorObs(highPerceptionsNear);

        if (FarPerceptionsEnabled)
        {
            var farOffsetLow = new Vector3(0f, LowPerceptionHeightOffset, FarDistanceOffset);
            var farOffsetHigh = new Vector3(0f, HighPerceptionHeightOffset, FarDistanceOffset);
            List<float> highPerceptionsFar = rayPerception.Perceive(RayLength, angles, fishTags, farOffsetLow, Vector3.zero, Color.red);
            List<float> lowPerceptionsFar = rayPerception.Perceive(RayLength, angles, obstacleTags, farOffsetHigh, Vector3.zero, Color.yellow);

            AddVectorObs(lowPerceptionsFar);
            AddVectorObs(highPerceptionsFar);
        }
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        int action = Mathf.FloorToInt(vectorAction[0]);
        switch(action){
            case 0:
                ChangeLaneDirectly(1);
                break;
            case 1:
                ChangeLaneDirectly(0);
                break;
            case 2:
                ChangeLaneDirectly(2);
                break;
            case 4:
                if (isVerticalMovementEnabled)
                    Jump();
                break;
            case 5:
                if (isVerticalMovementEnabled)
                    Slide();
                break;
        }

        //int currentMeter = Mathf.FloorToInt(trackManager.worldDistance);
        //if (currentMeter > lastMeterPassed && currentMeter > 0 && currentMeter % trackManager.UnitDistance == 0) {
        AddReward(1f / agentParameters.maxStep);
        if (Application.isEditor)
        {
            Monitor.Log("Reward", GetReward());
            Monitor.Log("Cummulative", GetCumulativeReward());
            Monitor.Log("Step", GetStepCount());
        }
            //lastMeterPassed = currentMeter;
        //}
    }

    public override void AgentReset()
    {
        lastMeterPassed = 0;

        ((GameState)GameManager.instance.FindState("Game")).ResetAll();
    }

#endregion
}
