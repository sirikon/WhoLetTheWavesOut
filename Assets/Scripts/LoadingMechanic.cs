using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMechanic : MonoBehaviour
{
    public Texture loadingRight, loadingLeft, loadingTexture;

    public int loadingRightWidth, loadingLeftWidth, loadingRightHeight, loadingLeftHeight;

    public bool loadingEnter, loadingEnterDone, loadingExit, loadingExitDone, loadingTimerSet;
    public int loadingTimerBaseEnter, loadingTimerBaseExit;
    public double loadingTimer, loadingDelayTimer;

    string sceneToLoad;

    // Use this for initialization
    void Start()
    {
        loadingRight = Resources.Load("LoadingRight") as Texture;
        loadingLeft = Resources.Load("LoadingLeft") as Texture;
        loadingTexture = Resources.Load("Loading") as Texture;

        loadingTimerBaseEnter = 10;
        loadingTimerBaseExit = 0;
        loadingDelayTimer = 0;

        loadingEnter = false;
        loadingExit = false;
        loadingTimerSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        LoadingEnterAnimation();
        LoadingExitAnimation();
    }

    void LoadingEnter()
    {

    }

    //This function receives the scene or button calling and sets what scene has to be loaded
    public void SetNextScene(string caller)
    {
        if (caller == "StartButton")
            sceneToLoad = "Iskander";

        loadingEnter = true;
    }

    public void StartNewScene()
    {
        loadingExit = true;
    }

    void LoadingEnterAnimation()
    {
        if (loadingEnter == true)
        {
            if (loadingTimerSet == false)
            {
                loadingTimer = loadingTimerBaseEnter;
                loadingTimerSet = true;
            }

            //Keep going with the loading animation until it's done
            loadingTimer -= 0.1;
            loadingDelayTimer += 0.1;

            if (loadingTimer <= 0)
            {
                loadingTimer = 0;
            }

            if (loadingDelayTimer >= 20)
            {
                loadingTimerSet = false;
                loadingEnter = false;
                loadingEnterDone = true;
                loadingDelayTimer = 0;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    void LoadingExitAnimation()
    {
        if (loadingExit == true)
        {
            if (loadingTimerSet == false)
            {
                loadingTimer = loadingTimerBaseExit;
                loadingTimerSet = true;
            }

            //Keep going with the loading animation until it's done
            loadingTimer += 0.1;
            loadingDelayTimer += 0.1;

            if (loadingTimer >= 10)
            {
                loadingTimer = 10;
            }

            if (loadingDelayTimer >= 20)
            {
                loadingTimerSet = false;
                loadingExit = false;
                loadingExitDone = true;
                loadingDelayTimer = 0;
            }
        }
    }

    public void LoadingGUI()
    {
        if (!loadingRight || !loadingLeft)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        if(loadingEnter == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 + (float)loadingTimer * 100, 0, Screen.width / 2, Screen.height), loadingRight);
            GUI.DrawTexture(new Rect(-(float)loadingTimer * 100, 0, Screen.width / 2, Screen.height), loadingLeft);
        }

        if(loadingEnterDone == true)
        {
            GUI.DrawTexture(new Rect(-3, 0, Screen.width, Screen.height), loadingTexture);
        }

        if(loadingExit == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 + (float)loadingTimer * 100, 0, Screen.width / 2, Screen.height), loadingRight);
            GUI.DrawTexture(new Rect(-(float)loadingTimer * 100, 0, Screen.width / 2, Screen.height), loadingLeft);
        }
    }
}
