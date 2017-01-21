using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private MagnetismOrigin magnetismOrigin;
    private Renderer renderer;

    public CustomInputButton ActivationButton;

	// Use this for initialization
	void Start () {
        magnetismOrigin = GetComponent<MagnetismOrigin>();
        renderer = GetComponent<Renderer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (CustomInput.GetButton(ActivationButton))
            magnetismOrigin.State = MagnetismOriginState.Enabled;
        else
            magnetismOrigin.State = MagnetismOriginState.Disabled;

        updateColor();
    }

    private void updateColor()
    {
        Color colorToSet = Color.black;

        if (magnetismOrigin.State == MagnetismOriginState.Enabled)
        {
            if (magnetismOrigin.ImpulseMode == ImpulseMode.Attract)
            {
                colorToSet = Color.green;
            }
            else
            {
                colorToSet = Color.red;
            }
        }

        renderer.material.color = colorToSet;
    }
}
