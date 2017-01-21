using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(CreateWaves(3));
	}

    IEnumerator CreateWaves(int waves)
    {
        for(var i = 0; i < waves; i++)
        {
            StartCoroutine(CreateWave(10));
            yield return new WaitForSeconds(30);
        }
    }

    IEnumerator CreateWave(int balls)
    {
        for(var i = 0; i < balls; i++)
        {
            InstantiateNewBall();
            yield return new WaitForSeconds(0.5F);
        }
    }

    GameObject createBall()
    {
        return (GameObject)Instantiate(Resources.Load("Prefabs/Ball"));
    }

    void InstantiateNewBall() {
        var go = createBall();
        var newPosition = Random.insideUnitSphere * 3;
        newPosition.y += 10;
        go.transform.position = newPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
