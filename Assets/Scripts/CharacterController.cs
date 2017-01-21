using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    MagnetismOrigin magnetismOrigin;
    public int PlayerNumber;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        magnetismOrigin = GetComponent<MagnetismOrigin>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float z = Input.GetAxis("Vertical " + PlayerNumber) * 10 * Time.deltaTime;
        float x = Input.GetAxis("Horizontal " + PlayerNumber) * 10 * Time.deltaTime;
        Vector3 translation = new Vector3(x, 0, z);
                
        transform.LookAt(transform.position + translation);
        transform.Translate(0, 0, translation.magnitude);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        magnetismOrigin.State = 
            CustomInput.GetButton(CustomInputButton.PlayerAction) ? 
            MagnetismOriginState.Enabled : 
            MagnetismOriginState.Disabled;
    }
}
