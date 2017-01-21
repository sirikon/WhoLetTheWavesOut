using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    CharacterController owner;
    Renderer renderer;
    Light light;

    public CharacterController Owner
    {
        get { return owner; }
        set
        {
            owner = value;
            updateColor();
        }
    }

    void Start()
    {
        renderer = GetComponent<Renderer>();
        light = GetComponentInChildren<Light>();
    }

    void updateColor()
    {
        if (Owner != null)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Owner.PlayerColor);
            light.color = owner.PlayerColor;
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
        
    }
}
