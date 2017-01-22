using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private MagnetismOrigin magnetismOrigin;
    GameObject panelesEmpty;
    GameObject panelesFull;
    Light light;
    private Renderer renderer;

    public bool Selected; 
    public CustomInputButton ActivationButton;

	// Use this for initialization
	void Start () {
        magnetismOrigin = GetComponent<MagnetismOrigin>();
        renderer = GetComponent<Renderer>();
        panelesEmpty = transform.Find("Torre_paneles_empty").gameObject;
        panelesFull = transform.Find("Torre_paneles_full").gameObject;
        light = GetComponentInChildren<Light>();
	}

    // Update is called once per frame
    void Update()
    {
        if (CustomInput.GetButton(ActivationButton))
            magnetismOrigin.State = MagnetismOriginState.Enabled;
        else
            magnetismOrigin.State = MagnetismOriginState.Disabled;

        updateColor();
        //updateShader();
    }

    private void updateColor()
    {
        var isEnabled = magnetismOrigin.State == MagnetismOriginState.Enabled;
        panelesEmpty.SetActive(!isEnabled);
        panelesFull.SetActive(isEnabled);
        light.enabled = isEnabled;
    }

    //private void updateShader()
    //{
    //    renderer.material.SetFloat("Outline", Selected ? 0.083F : 0);
    //    renderer.material.SetColor("OutlineColor", magnetismOrigin.ImpulseMode == ImpulseMode.Attract ? Color.green : Color.red);
    //}
}
