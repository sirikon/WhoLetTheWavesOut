using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    CharacterController owner;
    Renderer renderer;

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
    }

    void updateColor()
    {
        GetComponent<Renderer>().material.color = Owner.PlayerColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        var ballReceiver = other.gameObject.GetComponent<BallReceiverController>();
        if (ballReceiver)
        {
            Destroy(gameObject, 1);
            Debug.Log("PUNTO PA'L PLAYER " + Owner != null ? Owner.PlayerNumber : 0);
        }
    }
}
