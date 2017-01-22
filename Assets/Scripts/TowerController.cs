using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private MagnetismOrigin magnetismOrigin;
    GameObject panelesEmpty;
    GameObject panelesFull;
    private Renderer renderer;

    public bool Selected; 
    public CustomInputButton ActivationButton;

	// Use this for initialization
	void Start () {
        magnetismOrigin = GetComponent<MagnetismOrigin>();
        renderer = GetComponent<Renderer>();
        panelesEmpty = transform.Find("Torre_paneles_empty").gameObject;
        panelesFull = transform.Find("Torre_paneles_full").gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        if (CustomInput.GetButton(ActivationButton))
            magnetismOrigin.State = MagnetismOriginState.Enabled;
        else
            magnetismOrigin.State = MagnetismOriginState.Disabled;

        //updateColor();
        //updateShader();
    }

    //private void updateColor()
    //{

    //    if (magnetismOrigin.State == MagnetismOriginState.Enabled)
    //    {
    //        panelesEmpty.acti
    //        colorToSet = magnetismOrigin.ImpulseMode == ImpulseMode.Attract ?
    //            Color.green :
    //            Color.red;
    //    }

    //    renderer.material.color = colorToSet;
    //}

    //private void updateShader()
    //{
    //    renderer.material.SetFloat("Outline", Selected ? 0.083F : 0);
    //    renderer.material.SetColor("OutlineColor", magnetismOrigin.ImpulseMode == ImpulseMode.Attract ? Color.green : Color.red);
    //}
}
