using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismTarget : MonoBehaviour {

    MagnetismOrigin[] magnetismOrigins;
    public Rigidbody Rb;

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody>();
        magnetismOrigins = FindObjectsOfType<MagnetismOrigin>();
	}
	
	void FixedUpdate () {

        var forceToApply = new Vector3();

        float distance = 0;
        Vector3 direction = new Vector3();
        MagnetismOrigin origin;
        float impulse;
        int i;
        Vector3 calculatedForce;
        //Debug.Log("======");
		for(i = 0; i < magnetismOrigins.Length; i++)
        {
            origin = magnetismOrigins[i];
            distance = Utils.DistanceBetween(Rb.position, origin.Rb.position);
            if (distance > origin.MaxDistance) continue;

            impulse = origin.MinImpulse + ((1 / Mathf.Pow(distance, 2)) * (origin.MaxImpulse - origin.MinImpulse));

            direction = Utils.DirectionFromAToB(Rb.position, origin.Rb.position);

            calculatedForce = direction * GetForceModifier(origin.ImpulseMode) * impulse;

            //Debug.Log(impulse);

            forceToApply += calculatedForce;
        }

        forceToApply.y = Mathf.Min(forceToApply.y, Rb.mass * 0.65F);

        Rb.AddForce(forceToApply);
	}

    // Forward or Backward?
    public int GetForceModifier(ImpulseMode forceMode)
    {
        return forceMode == ImpulseMode.Attract ? 1 : -1;
    }

}

public enum ImpulseMode
{
    Attract,
    Repulse
}