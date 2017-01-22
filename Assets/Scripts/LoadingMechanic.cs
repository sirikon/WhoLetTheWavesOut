using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMechanic : MonoBehaviour
{
    Texture loadingRight, loadingLeft, loadingTexture;

    int loadingRightWidth, loadingLeftWidth, loadingRightHeight, loadingLeftHeight;

    public bool loadingEnter, loadingEnterDone, loadingExit, loadingExitDone, loadingTimerSet, noLoad;
    int loadingTimerBaseEnter, loadingTimerBaseExit, loadingTimerLimitDelay;
    double loadingTimer, loadingDelayTimer;

    int animationSpeed;

    string sceneToLoad;

    // Use this for initialization
    void Start()
    {
        loadingRight = Resources.Load("LoadingRight") as Texture;
        loadingLeft = Resources.Load("LoadingLeft") as Texture;
        loadingTexture = Resources.Load("Loading") as Texture;

        loadingTimerBaseEnter = 2;
        loadingTimerBaseExit = 0;

        loadingTimerLimitDelay = 5;
        loadingDelayTimer = 0;

        loadingEnter = false;
        loadingExit = false;
        loadingTimerSet = false;
        noLoad = false;

        animationSpeed = 500;
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
            sceneToLoad = "Carlos";

        if (caller == "GameEnd")
            sceneToLoad = "Carlos";

        if (caller == "MainMenu")
            sceneToLoad = "Main Menu";
           
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
            loadingTimer -= Time.deltaTime;
            loadingDelayTimer += Time.deltaTime;

            if (loadingTimer <= 0)
            {
                loadingTimer = 0;
            }

            if (loadingDelayTimer >= loadingTimerLimitDelay)
            {
                loadingTimerSet = false;
                loadingEnter = false;
                loadingEnterDone = true;
                loadingDelayTimer = 0;

                if (noLoad == false)
                    SceneManager.LoadScene(sceneToLoad);
                else
                    noLoad = false;
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
            loadingTimer += Time.deltaTime;
            loadingDelayTimer += Time.deltaTime;

            if (loadingTimer >= 5)
            {
                loadingTimer = 5;
            }

            if (loadingDelayTimer >= loadingTimerLimitDelay)
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
            GUI.DrawTexture(new Rect(Screen.width / 2 + (float)loadingTimer * animationSpeed, 0, Screen.width / 2, Screen.height), loadingRight);
            GUI.DrawTexture(new Rect(-(float)loadingTimer * animationSpeed, 0, Screen.width / 2, Screen.height), loadingLeft);
        }

        if(loadingEnterDone == true)
        {
            GUI.DrawTexture(new Rect(-3, 0, Screen.width, Screen.height), loadingTexture);
        }

        if(loadingExit == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 + (float)loadingTimer * animationSpeed, 0, Screen.width / 2, Screen.height), loadingRight);
            GUI.DrawTexture(new Rect(-(float)loadingTimer * animationSpeed, 0, Screen.width / 2, Screen.height), loadingLeft);
        }
    }
}
