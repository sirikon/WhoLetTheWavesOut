using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    MagnetismOrigin magnetismOrigin;
    public int PlayerNumber;
    private Renderer renderer;
    Rigidbody rb;

    public Color PlayerColor
    {
        get
        {
            Color color = Color.white;
            switch (PlayerNumber)
            {
                case 1:
                    color = Color.magenta;
                    break;
                case 2:
                    color = Color.cyan;
                    break;
            }

            return color;
        }
    }

	// Use this for initialization
	void Start () {
        magnetismOrigin = GetComponent<MagnetismOrigin>();
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        renderer.material.color = PlayerColor;
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
            CustomInput.GetButton(CustomInputButton.PlayerAction, PlayerNumber) ? 
            MagnetismOriginState.Enabled : 
            MagnetismOriginState.Disabled;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") {
            collision.gameObject.GetComponent<Renderer>().material.color = PlayerColor;
        }
    }
}
