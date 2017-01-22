using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour {

    bool creatingWaves = false;

	// Use this for initialization
	void Start () {

    }

    IEnumerator CreateWave(int balls)
    {
        for(var i = 0; i < balls; i++)
        {
            InstantiateNewBall();
            yield return new WaitForSeconds(0.5F);
        }
        creatingWaves = false;
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

    void clearBalls()
    {
        var balls = GameObject.FindObjectsOfType<BallController>();
        for (var i = 0; i < balls.Length; i++)
        {
            if (balls[i].transform.position.y <= -2)
                Destroy(balls[i].gameObject);
        }
    }

    int remainingBalls() {
        var remainingBalls = 0;
        var balls = GameObject.FindObjectsOfType<BallController>();
        for(var i = 0; i < balls.Length; i++)
        {
            if (balls[i].transform.position.y >= -2)
                remainingBalls++;
        }
        return remainingBalls;
    }
	
	// Update is called once per frame
	void Update () {
		if (remainingBalls() <= 2 && !creatingWaves)
        {
            clearBalls();
            creatingWaves = true;
            StartCoroutine(CreateWave(10));
        }
	}
}
