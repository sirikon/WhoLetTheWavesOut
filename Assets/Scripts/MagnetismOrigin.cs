using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismOrigin : MonoBehaviour {

    public MagnetismOriginState State;
    public ImpulseMode ImpulseMode;
    public int MaxDistance = 10;
    public int MaxImpulse = 10;
    public int MinImpulse = 7;

    // Use this for initialization
    void Start () {

    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

public enum MagnetismOriginState
{
    Enabled,
    Disabled
}
