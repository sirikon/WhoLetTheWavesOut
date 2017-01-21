using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float z = Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
        Vector3 translation = new Vector3(x, 0, z);
                
        transform.LookAt(transform.position + translation);
        transform.Translate(0, 0, translation.magnitude);
        //transform.Rotate(0, rotation, 0);
    }
}
