using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int playerScore;
    public float powerLevel, maxPowerLevel;
    public string playerID;

	// Use this for initialization
	void Start () {
        maxPowerLevel = 100;
        playerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
