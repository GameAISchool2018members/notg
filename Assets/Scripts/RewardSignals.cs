using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSignals : MonoBehaviour {

	public int reward;

	public void updateSignal(int newReward){
		this.reward+= newReward;
		print ("Rewards right now: " + reward);
	}

	public int getSignal(){
		return this.reward;
	}
}
