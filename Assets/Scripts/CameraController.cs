using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraController : MonoBehaviour {

    Camera camera;
    PostProcessingBehaviour postpo;
    public float shake = 0;
    public float shakeAmount = 0.7F;
    public float decreaseFactor = 1.0F;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        postpo = GetComponent<PostProcessingBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shake > 0)
        {
            camera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
            ChromaticAberrationModel.Settings settings = new ChromaticAberrationModel.Settings();
            settings.intensity = Random.value;
            postpo.profile.chromaticAberration.settings = settings;
        }
        else
        {
            camera.transform.localPosition = new Vector3();
            ChromaticAberrationModel.Settings settings = new ChromaticAberrationModel.Settings();
            settings.intensity = 0.45F;
            postpo.profile.chromaticAberration.settings = settings;
            shake = 0;
        }
    }
}
