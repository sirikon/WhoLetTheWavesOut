using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismOrigin : MonoBehaviour {

    private new Rigidbody rigidbody;
    public MagnetismOriginState State;
    public ImpulseMode ImpulseMode;
    public int MaxDistance = 10;
    public int MaxImpulse = 10;
    public int MinImpulse = 7;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return rigidbody;
    }
}

public enum MagnetismOriginState
{
    Enabled,
    Disabled
}
