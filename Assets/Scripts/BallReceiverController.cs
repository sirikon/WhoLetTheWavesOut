using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReceiverController : MonoBehaviour {

    ParticleSystem particleSystem;
    int particleActivationCount = 0;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallController>();
        if (ball)
        {
            Destroy(ball.gameObject, 1);
            Debug.Log("PUNTO PA'L PLAYER " + ball.Owner != null ? ball.Owner.PlayerNumber : 0);
            if (ball.Owner != null)
            {
                particleSystem.startColor = ball.Owner.PlayerColor;
                particleSystem.Play();
                particleActivationCount += 1;
                StartCoroutine(turnDownParticleSystem());
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
