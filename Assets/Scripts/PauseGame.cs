using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    bool isPaused = false;
    bool pausedOnTexture = false;
    bool pauseChangeTexture = false;
    Texture pauseOnTexture, pauseOffTexture; public Texture pauseTexture;

    public float pauseDelay, previousTimeSinceStartup, realTimeSinceStartup, deltaTime;

	// Use this for initialization
	void Start () {
        pauseOnTexture = Resources.Load("PauseOn") as Texture;
        pauseOffTexture = Resources.Load("PauseOff") as Texture;
        pauseTexture = pauseOnTexture;

        pauseDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            previousTimeSinceStartup = Time.realtimeSinceStartup - 1;
            realTimeSinceStartup = Time.realtimeSinceStartup;
            deltaTime = realTimeSinceStartup - previousTimeSinceStartup;
            previousTimeSinceStartup = realTimeSinceStartup;

            pauseDelay += deltaTime;
        }

        if (pauseDelay >= 0 && pauseDelay < 40)
            pauseTexture = pauseOnTexture;
        else if (pauseDelay >= 40 && pauseDelay < 80)
            pauseTexture = pauseOffTexture;
        else if (pauseDelay > 80)
            pauseDelay = 0;

        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            if (isPaused)
                Time.timeScale = 0;
            else
            {
                Time.timeScale = 1;
                pauseDelay = 0;
            }
        }
    }

    void OnGUI()
    {
        if (isPaused)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseTexture);
        }
    }
}
