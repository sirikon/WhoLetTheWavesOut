using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour {
    
    GameObject player1, player2;
    PlayerStats player1Stats, player2Stats;

    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player1Stats = player1.GetComponent<PlayerStats>();
        player2Stats = player2.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var Player = other.gameObject.GetComponent<CharacterController>();
        if (Player == null) return;
        
        if (Player.PlayerNumber == 1)
            player1Stats.powerLevel += 20;
        else if (Player.PlayerNumber == 2)
            player2Stats.powerLevel += 20;
        
        //if (this.gameObject == Capsule)
        //{
        Destroy(this.gameObject,0);
        //}
    }
}
