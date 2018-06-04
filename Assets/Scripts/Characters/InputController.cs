using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Agent {

    public AudioSource powerupSource;
    public CharacterCollider characterCollider;

    static int s_MovingHash = Animator.StringToHash("Moving");
    static int s_RunStartHash = Animator.StringToHash("runStart");



    public TrackManager trackManager;

    public Character character;

    public int maxLife = 1;

    public List<Consumable> consumables { get { return m_ActiveConsumables; } }
    public int currentLife { get { return m_CurrentLife; } set { m_CurrentLife = value; } }
    public int coins { get { return m_Coins; } set { m_Coins = value; } }
    public int premium { get { return m_Premium; } set { m_Premium = value; } }

    public AudioClip powerUpUseSound;


    protected List<Consumable> m_ActiveConsumables = new List<Consumable>();
    protected int m_CurrentLife;
    protected int m_Coins;
    protected int m_Premium;

    protected bool m_IsInvincible;

    protected int m_CharIndex;

    // Cheating functions, use for testing
    public void CheatInvincible(bool invincible)
    {
        m_IsInvincible = invincible;
    }

    public bool IsCheatInvincible()
    {
        return m_IsInvincible;
    }

    public void StartRunning()
    {
        if (character.animator)
        {
            character.animator.Play(s_RunStartHash);
            character.animator.SetBool(s_MovingHash, true);
        }
    }

    public void StopMoving()
    {
        trackManager.StopMove(m_CharIndex);
        if (character.animator)
        {
            character.animator.SetBool(s_MovingHash, false);
        }
    }

    public void UseConsumable(Consumable c)
    {
        characterCollider.audio.PlayOneShot(powerUpUseSound);

        for (int i = 0; i < m_ActiveConsumables.Count; ++i)
        {
            if (m_ActiveConsumables[i].GetType() == c.GetType())
            {
                // If we already have an active consumable of that type, we just reset the time
                m_ActiveConsumables[i].ResetTime();
                Destroy(c.gameObject);
                return;
            }
        }

        // If we didn't had one, activate that one 
        c.transform.SetParent(transform, false);
        c.gameObject.SetActive(false);

        m_ActiveConsumables.Add(c);
        c.Started(this);
    }

    public void CoinCollided()
    {
        AddReward(trackManager.RewardForCoin);
    }

    public void ObstacleCollided()
    {
        AddReward(trackManager.RewardForObstacle);
    }
}
