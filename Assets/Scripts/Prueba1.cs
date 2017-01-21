using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba1 : MonoBehaviour {

    LoadingMechanic loadPrueba;

	// Use this for initialization
	void Start () {
        loadPrueba = gameObject.AddComponent<LoadingMechanic>();
        loadPrueba.StartNewScene();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
