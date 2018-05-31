using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSignals : MonoBehaviour {

	public float reward;

	public void updateSignal(float newReward){
		this.reward+= newReward;
        //Debug.Log("Reward is " + reward);
	}

	public float getSignal(){
		return this.reward;
	}

    public void Reset()
    {
        this.reward = 0;
    }
}
