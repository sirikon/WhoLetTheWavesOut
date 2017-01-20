using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismTarget : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Forward or Backward?
    public int GetForceModifier(ImpulseMode forceMode)
    {
        return forceMode == ImpulseMode.Attract ? 1 : -1;
    }

    public void AddForceTo(float thrust, Rigidbody target, ImpulseMode forceMode)
    {
        if (!enabled) return;

        var heading = target.position - rb.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        Debug.DrawLine(rb.position, target.position);
        rb.AddForce(direction * GetForceModifier(forceMode) * thrust);
    }

}

public enum ImpulseMode
{
    Attract,
    Repulse
}