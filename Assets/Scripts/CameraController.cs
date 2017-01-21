using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Camera camera;
    public float shake = 0;
    public float shakeAmount = 0.7F;
    public float decreaseFactor = 1.0F;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shake > 0)
        {
            camera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            camera.transform.localPosition = new Vector3();
            shake = 0;
        }
    }
}
