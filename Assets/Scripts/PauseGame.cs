using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    bool isPaused = false;
    bool pausedOnTexture = false;
    bool pauseChangeTexture = false;
    Texture whiteTexture, pause1Texture, pause2Texture, pause3Texture, pause4Texture;
    public Texture pauseTexture;

    public float pauseDelay, previousTimeSinceStartup, realTimeSinceStartup, deltaTime;

	// Use this for initialization
	void Start () {
        whiteTexture = Resources.Load("WhiteSquare") as Texture;
        pause1Texture = Resources.Load("Pause 1") as Texture;
        pause2Texture = Resources.Load("Pause 2") as Texture;
        pause3Texture = Resources.Load("Pause 3") as Texture;
        pause4Texture = Resources.Load("Pause 4") as Texture;
        pauseTexture = pause1Texture;

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
            pauseTexture = pause1Texture;
        else if (pauseDelay >= 40 && pauseDelay < 80)
            pauseTexture = pause2Texture;
        else if (pauseDelay >= 80 && pauseDelay < 120)
            pauseTexture = pause3Texture;
        else if (pauseDelay >= 120 && pauseDelay < 160)
            pauseTexture = pause4Texture;
        else if (pauseDelay >= 160 && pauseDelay < 200)
            pauseDelay = 0;

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick button 7"))
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
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), whiteTexture);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseTexture, ScaleMode.ScaleToFit);
        }
    }
}
