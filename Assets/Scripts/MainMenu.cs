using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Texture MainBackgroundTexture, TitleTexture, QuitTexture;
    public Texture StartGameButton, CreditsButton, QuitGameButton, QuitYesButton, QuitNoButton;

    public int buttonWidthDivider, buttonHeightDivider, buttonPosXExtra, buttonStartPosYExtra, buttonCreditsPosYExtra,
               buttonQuitPosYExtra, buttonQuitYesPosYExtra, buttonQuitNoPosYExtra;
    int buttonWidth, buttonHeight, buttonPosX, buttonStartPosY, buttonCreditsPosY, buttonQuitPosY, buttonQuitYesPosY, 
        buttonQuitNoPosY;

    public int textureWidthDivider, textureHeightDivider, texturePosXExtra, titleTexturePosYExtra, quitTexturePosYExtra;
    int textureWidth, textureHeight, texturePosX, titleTexturePosY, quitTexturePosY;

    bool mainMenu, quitGameMenu;
    
    public LoadingMechanic loadingMain;

    // Use this for initialization
    void Start () {
        loadingMain = gameObject.AddComponent<LoadingMechanic>();

        mainMenu = true;
        quitGameMenu = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void QuitGame()
    {
        mainMenu = false;
        quitGameMenu = true;
    }

    void OnGUI()
    {
        if (!MainBackgroundTexture)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        //General Variables
        buttonWidth = Screen.width / buttonWidthDivider;
        buttonHeight = Screen.height / buttonHeightDivider;
        buttonPosX = Screen.width / 2 - buttonWidth / 2 + buttonPosXExtra;

        textureWidth = Screen.width / textureWidthDivider;
        textureHeight = Screen.height / textureHeightDivider;
        texturePosX = Screen.width / 2 - textureWidth / 2 + texturePosXExtra;

        //Main Menu Variables
        titleTexturePosY = Screen.height / 2 - textureHeight / 2 + quitTexturePosYExtra;

        buttonStartPosY = Screen.height / 2 - buttonHeight / 2 + buttonStartPosYExtra;
        buttonCreditsPosY = Screen.height / 2 - buttonHeight / 2 + buttonCreditsPosYExtra;
        buttonQuitPosY = Screen.height / 2 - buttonHeight / 2 + buttonQuitPosYExtra;

        //Quit Menu Variables
        quitTexturePosY = Screen.height / 2 - textureHeight / 2 + quitTexturePosYExtra;

        buttonQuitYesPosY = Screen.height / 2 - buttonHeight / 2 + buttonQuitYesPosYExtra;
        buttonQuitNoPosY = Screen.height / 2 - buttonHeight / 2 + buttonQuitNoPosYExtra;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MainBackgroundTexture);

        if (mainMenu == true) //If Main Menu is displayed, show main menu buttons
        {
            GUI.DrawTexture(new Rect(texturePosX, titleTexturePosY, textureWidth, textureHeight), TitleTexture);

            if (GUI.Button(new Rect(buttonPosX, buttonStartPosY, buttonWidth, buttonHeight), StartGameButton))
            {
                Debug.Log("Game Start");
                loadingMain.SetNextScene("StartButton");
            }

            if (GUI.Button(new Rect(buttonPosX, buttonCreditsPosY, buttonWidth, buttonHeight), CreditsButton))
            {
                Debug.Log("Credits");
            }

            if (GUI.Button(new Rect(buttonPosX, buttonQuitPosY, buttonWidth, buttonHeight), QuitGameButton))
            {
                QuitGame();
            }
        }

        if(quitGameMenu == true) //If Quit button is pressed, show quit menu buttons
        {
            GUI.DrawTexture(new Rect(texturePosX, quitTexturePosY, textureWidth, textureHeight), QuitTexture);

            if (GUI.Button(new Rect(buttonPosX, buttonQuitYesPosY, buttonWidth, buttonHeight), QuitYesButton))
            {
                Application.Quit();
            }

            if (GUI.Button(new Rect(buttonPosX, buttonQuitNoPosY, buttonWidth, buttonHeight), QuitNoButton))
            {
                mainMenu = true;
                quitGameMenu = false;
            }
        }

        loadingMain.LoadingGUI();
    }
}
