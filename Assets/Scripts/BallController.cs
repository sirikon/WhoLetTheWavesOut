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
            if (owner != value)
            {
                owner = value;
                updateColor();
            }
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
            var audioSource = Instantiate(Owner.ChangeColorAudio);
            Destroy(audioSource.gameObject, 2);
            audioSource.Play();
        }
        else
        {
            light.enabled = false;
        }
        
    }
}
