using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Texture mainBackgroundTexture, logoTexture, quitTexture;
    public Texture startGameButtonSelected, startGameButtonUnselected, creditsButtonSelected, creditsButtonUnselected,
                   quitGameButtonSelected, quitGameButtonUnselected, quitYesButtonSelected, quitYesButtonUnselected,
                   quitNoButtonSelected, quitNoButtonUnselected, iskanderTexture, louisTexture, akiTexture, luisTexture,
                   carlosTexture, logoOffTexture, logoOnTexture, backButton;

    Texture startGameButton, creditsButton, quitGameButton, quitYesButton, quitNoButton;

    public int buttonWidthDivider, buttonHeightDivider, buttonStartPosYExtra, buttonCreditsPosYExtra,
               buttonQuitPosYExtra, buttonQuitYesPosYExtra, buttonQuitNoPosYExtra;
    float buttonWidth, buttonHeight, buttonStartPosY, buttonCreditsPosY, buttonQuitPosY, buttonQuitYesPosY, 
        buttonQuitNoPosY, nameSizeX, nameSizeY, namePosX, namePosY, logoSizeX, logoSizeY, logoPosX, logoPosY,
        backButtonSizeX, backButtonSizeY, backButtonPosX, backButtonPosY;

    float introTimer, introTimerAux, introButtonsTimer, axisDelayTimer, confirmDelayTimer;

    public float textureWidthDivider, textureHeightDivider, texturePosXExtra, titleTexturePosYExtra, quitTexturePosYExtra;
    float textureWidth, textureHeight, texturePosX, titleTexturePosY, titleTexturePosYIntro, quitTexturePosY;

    bool introMenu, mainMenu, creditsMenu, quitGameMenu;
    
    public LoadingMechanic loadingMain;

    int buttonSelected;

    // Use this for initialization
    void Start () {
        loadingMain = gameObject.AddComponent<LoadingMechanic>();

        introTimer = 10;
        introButtonsTimer = 0;
        axisDelayTimer = 0;
        confirmDelayTimer = 0;

        introMenu = true;
        mainMenu = false;
        creditsMenu = false;
        quitGameMenu = false;
        buttonSelected = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if(introMenu)
        {
            if(introTimer > 0)
                introTimer -= Time.deltaTime * 2;
            else
            {
                introMenu = false;
                mainMenu = true;
            }
        }

        introButtonsTimer += Time.deltaTime;

        MoveOnButtons();

        if(axisDelayTimer > 0)
        {
            axisDelayTimer -= Time.deltaTime;
        }

        if(confirmDelayTimer > 0)
        {
            confirmDelayTimer -= Time.deltaTime;
        }
	}

    void MoveOnButtons()
    {
        if (mainMenu == true)
        {
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical 1") < 0) && axisDelayTimer <= 0)
            {
                axisDelayTimer = 0.25f;

                if (buttonSelected == 3)
                    buttonSelected = 1;
                else
                    buttonSelected += 1;
            }

            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical 1") > 0) && axisDelayTimer <= 0)
            {
                axisDelayTimer = 0.25f;

                if (buttonSelected == 1)
                    buttonSelected = 3;
                else
                    buttonSelected -= 1;
            }

            if (buttonSelected == 1)
            {
                startGameButton = startGameButtonSelected;
            }
            else
            {
                startGameButton = startGameButtonUnselected;
            }

            if (buttonSelected == 2)
            {
                creditsButton = creditsButtonSelected;
            }
            else
            {
                creditsButton = creditsButtonUnselected;
            }

            if (buttonSelected == 3)
            {
                quitGameButton = quitGameButtonSelected;
            }
            else
            {
                quitGameButton = quitGameButtonUnselected;
            }

            if (Input.GetKeyDown("joystick button 0") && confirmDelayTimer <= 0)
            {
                confirmDelayTimer = 0.25f;

                if (buttonSelected == 1) //Start Game
                {
                    Debug.Log("Game Start");
                    loadingMain.SetNextScene("StartButton");
                }

                if (buttonSelected == 2) //Credits
                {
                    Debug.Log("Credits");
                    mainMenu = false;
                    creditsMenu = true;
                    buttonSelected = 1;
                }

                if (buttonSelected == 3) //Quit Game
                {
                    Debug.Log("Quit Game");
                    buttonSelected = 1;
                    QuitGame();
                }
            }
        }

        if (quitGameMenu == true)
        {
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical 1") < 0) && axisDelayTimer <= 0)
            {
                axisDelayTimer = 0.25f;

                if (buttonSelected == 2)
                    buttonSelected = 1;
                else
                    buttonSelected += 1;
            }

            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical 1") > 0) && axisDelayTimer <= 0)
            {
                axisDelayTimer = 0.25f;

                if (buttonSelected == 1)
                    buttonSelected = 2;
                else
                    buttonSelected -= 1;
            }

            if (buttonSelected == 1) //Confirm quit
            {
                quitYesButton = quitYesButtonSelected;
            }
            else
            {
                quitYesButton = quitYesButtonUnselected;
            }

            if (buttonSelected == 2) //Cancel quit
            {
                quitNoButton = quitNoButtonSelected;
            }
            else
            {
                quitNoButton = quitNoButtonUnselected;
            }

            if (Input.GetKeyDown("joystick button 0") && confirmDelayTimer <= 0)
            {
                confirmDelayTimer = 0.25f;

                if (buttonSelected == 1) //Confirm Quit
                {
                    Debug.Log("Game Quit");
                    Application.Quit();
                }

                if (buttonSelected == 2) //Cancel quit
                {
                    Debug.Log("Cancel quit");
                    buttonSelected = 1;
                    mainMenu = true;
                    quitGameMenu = false;
                }
            }
        }

        if (creditsMenu == true)
        {
            if (Input.GetKeyDown("joystick button 0") && confirmDelayTimer <= 0)
            {
                confirmDelayTimer = 0.25f;

                if (buttonSelected == 1) //Back
                {
                    Debug.Log("Back");
                    creditsMenu = false;
                    mainMenu = true;
                }
            }
        }
    }

    void QuitGame()
    {
        mainMenu = false;
        quitGameMenu = true;
    }

    void OnGUI()
    {
        if (!mainBackgroundTexture)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        //General Variables
        buttonWidth = Screen.width / buttonWidthDivider;
        buttonHeight = Screen.height / buttonHeightDivider;

        textureWidth = Screen.width / textureWidthDivider;
        textureHeight = Screen.height / textureHeightDivider;
        texturePosX = Screen.width / 2 - textureWidth / 2 + texturePosXExtra;

        //Main Menu Variables

        introTimerAux = introTimer;

        if (introTimerAux < 1)
            introTimerAux = 1;

        titleTexturePosY = Screen.height / 2 - textureHeight / 2;
        titleTexturePosYIntro = Screen.height - (titleTexturePosY * introTimerAux) * 2;

        if (titleTexturePosYIntro > titleTexturePosY)
            titleTexturePosYIntro = titleTexturePosY;

        buttonStartPosY = titleTexturePosY - Screen.height / 25;
        buttonCreditsPosY = Screen.height - Screen.height / 10 - buttonHeight / 2;
        buttonQuitPosY = Screen.height - Screen.height / 10 - buttonHeight / 2;

        //Quit Menu Variables
        quitTexturePosY = Screen.height / 2 - textureHeight / 2 + quitTexturePosYExtra;

        buttonQuitYesPosY = Screen.height / 2 - buttonHeight / 2 + buttonQuitYesPosYExtra;
        buttonQuitNoPosY = Screen.height / 2 - buttonHeight / 2 + buttonQuitNoPosYExtra;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), mainBackgroundTexture);

        if(introMenu == true)
        {
            GUI.DrawTexture(new Rect(texturePosX, titleTexturePosYIntro, textureWidth, textureHeight), logoTexture);
        }

        if (mainMenu == true) //If Main Menu is displayed, show main menu buttons
        {
            GUI.DrawTexture(new Rect(texturePosX, titleTexturePosY, textureWidth, textureHeight), logoTexture);

            if (introButtonsTimer > 5.65f)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, buttonStartPosY, buttonWidth, buttonHeight), startGameButton))
                {
                    Debug.Log("Game Start");
                    loadingMain.SetNextScene("StartButton");
                }
            }

            if (introButtonsTimer > 6.5f)
            {
                if (GUI.Button(new Rect(Screen.width / 4 - buttonWidth / 2, buttonCreditsPosY, buttonWidth, buttonHeight), creditsButton))
                {
                    mainMenu = false;
                    creditsMenu = true;
                }
            }

            if (introButtonsTimer > 6.8f)
            {
                if (GUI.Button(new Rect(Screen.width - Screen.width / 4 - buttonWidth / 2, buttonQuitPosY, buttonWidth, buttonHeight), quitGameButton))
                {
                    QuitGame();
                }
            }

            if (introButtonsTimer > 7.2f)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width / 10, Screen.height / 10), logoTexture);
            }

            if (introButtonsTimer > 7.5f)
            {
                GUI.DrawTexture(new Rect(Screen.width - Screen.width / 8, 0, Screen.width / 10, Screen.height / 10), logoTexture);
            }
        }

        if(creditsMenu == true)
        {
            nameSizeX = Screen.width / 5;
            nameSizeY = Screen.height / 8;
            namePosX = Screen.width / 10;
            namePosY = Screen.height / 5;

            logoSizeX = Screen.width / 1.5f;
            logoSizeY = Screen.height / 1.5f;
            logoPosX = Screen.width - logoSizeX;
            logoPosY = Screen.height / 2 - logoSizeY / 2;

            backButtonSizeX = Screen.width / 5;
            backButtonSizeY = Screen.height / 5;
            backButtonPosX = Screen.width - backButtonSizeX;
            backButtonPosY = Screen.height - backButtonSizeY;

            //Carlos
            GUI.DrawTexture(new Rect(namePosX, namePosY * 0 + Screen.height / 20, nameSizeX, nameSizeY), carlosTexture);
            //Aki
            GUI.DrawTexture(new Rect(namePosX, namePosY * 1 + Screen.height / 20, nameSizeX, nameSizeY), luisTexture);
            //Luis
            GUI.DrawTexture(new Rect(namePosX, namePosY * 2 + Screen.height / 20, nameSizeX, nameSizeY), akiTexture);
            //Louis
            GUI.DrawTexture(new Rect(namePosX, namePosY * 3 + Screen.height / 20, nameSizeX, nameSizeY), louisTexture);
            //Iskander
            GUI.DrawTexture(new Rect(namePosX, namePosY * 4 + Screen.height / 20, nameSizeX, nameSizeY), iskanderTexture);
            //Logo
            GUI.DrawTexture(new Rect(logoPosX, logoPosY, logoSizeX, logoSizeY), logoOnTexture);
            //Botón atrás
            if (GUI.Button(new Rect(backButtonPosX, backButtonPosY, backButtonSizeX, backButtonSizeY), backButton))
            {
                creditsMenu = false;
                mainMenu = true;
            }
        }

        if (quitGameMenu == true) //If Quit button is pressed, show quit menu buttons
        {
            GUI.DrawTexture(new Rect(texturePosX, textureHeight / 4, textureWidth, textureHeight / 4), quitTexture);

            if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, buttonQuitYesPosY, buttonWidth, buttonHeight), quitYesButton))
            {
                Application.Quit();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, buttonQuitNoPosY, buttonWidth, buttonHeight), quitNoButton))
            {
                mainMenu = true;
                quitGameMenu = false;
            }
        }

        loadingMain.LoadingGUI();
    }
}
