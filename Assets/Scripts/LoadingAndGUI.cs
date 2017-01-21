using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAndGUI : MonoBehaviour {

    LoadingMechanic loadPrueba;
    GUIMechanics guiPrueba;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if(!loadPrueba.loadingExitDone)
            loadPrueba.StartNewScene();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Awake()
    {
        loadPrueba = gameObject.AddComponent<LoadingMechanic>();
        guiPrueba = gameObject.AddComponent<GUIMechanics>();
    }

    void OnGUI()
    {
        guiPrueba.drawGUI();
        loadPrueba.LoadingGUI();
    }
}
