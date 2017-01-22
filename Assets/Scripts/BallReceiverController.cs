using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReceiverController : MonoBehaviour {

    CameraController cameraController;
    ParticleSystem particleSystem;
    int particleActivationCount = 0;
    GameObject player1, player2;
    PlayerStats player1Stats, player2Stats;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        cameraController = FindObjectOfType<CameraController>();

        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player1Stats = player1.GetComponent<PlayerStats>();
        player2Stats = player2.GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallController>();
        if (ball == null) return;

        if (ball.Owner)
        {
            if (ball.Owner.PlayerNumber == 1)
                player1Stats.playerScore += 1;
            else if (ball.Owner.PlayerNumber == 2)
                player2Stats.playerScore += 1;
        }

        if (ball)
        {
            Destroy(ball.gameObject, 1);
            if (ball.Owner != null)
            {
                particleSystem.startColor = ball.Owner.PlayerColor;
                particleSystem.Play();
                particleActivationCount += 1;
                cameraController.shakeAmount = 0.12F;
                cameraController.shake = 1;
                StartCoroutine(turnDownParticleSystem());
                var audioSource = Instantiate(ball.Owner.GoalAudio);
                Destroy(audioSource.gameObject, 2);
                audioSource.Play();
            }
        }
    }

    IEnumerator turnDownParticleSystem()
    {
        yield return new WaitForSeconds(1);
        particleActivationCount -= 1;
        if (particleActivationCount == 0)
            particleSystem.Stop();  
    }
}
