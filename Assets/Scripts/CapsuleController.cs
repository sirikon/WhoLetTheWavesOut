using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour {
    
    GameObject player1, player2;
    PlayerStats player1Stats, player2Stats;
    Renderer renderer;
    Light light;

    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player1Stats = player1.GetComponent<PlayerStats>();
        player2Stats = player2.GetComponent<PlayerStats>();
        renderer = GetComponent<Renderer>();
        light = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!renderer.enabled) return;

        var Player = other.gameObject.GetComponent<CharacterController>();
        if (Player == null) return;

        renderer.enabled = false;
        light.enabled = false;

        if (Player.PlayerNumber == 1)
        {
            player1Stats.powerLevel += 20;
            if (player1Stats.maxPowerLevel < player1Stats.powerLevel)
                player1Stats.powerLevel = player1Stats.maxPowerLevel;
        }

        if (Player.PlayerNumber == 2)
        {
            player2Stats.powerLevel += 20;
            if (player2Stats.maxPowerLevel < player2Stats.powerLevel)
                player2Stats.powerLevel = player2Stats.maxPowerLevel;
        }

        StartCoroutine(Reactivate());
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(25);
        renderer.enabled = true;
        light.enabled = true;
    }
}
