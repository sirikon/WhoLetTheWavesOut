using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismOrigin : MonoBehaviour {

    MagnetismTarget[] magnetismTargets;
    Rigidbody rb;
    public ImpulseMode forceMode;

    // Use this for initialization
    void Start () {
        magnetismTargets = FindObjectsOfType<MagnetismTarget>();
        rb = GetComponent<Rigidbody>();
        Debug.Log(magnetismTargets.Length);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach(var target in magnetismTargets)
        {
            target.AddForceTo(10, rb, forceMode);
        }
	}
}
