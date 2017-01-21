using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMechanics : MonoBehaviour {

    Texture GUIBack, playerOneTexture, twoPointsTexture, playerTwoTexture, playerOnePowerTexture, PlayerTwoPowerTexture, PowerTexture;
    public float minutesNumber, secondsOneNumber, secondsTwoNumber;
    List<Texture> numbers = new List<Texture>();
    int GUIHeight, GUIHeightDivider, numberWidth, numberWidthDivider, playerIconWidth, playerIconWidthDivider,
        timerMinutesPosX, timerSecondsOnePosX, timerSecondsTwoPosX, playerPowerIconWidth, PlayerPowerIconWidthDivider,
        twoPointsPosX, powerLevelHeight, powerLevel1PosX, powerLevel2PosX;

    float powerLevelOnePercent;

    public float timer, player1PowerLevel, player2PowerLevel, powerLevel1Width, powerLevel2Width, powerLevelMaxWidth;

	// Use this for initialization
	void Start () {
        GUIBack = Resources.Load("GUIBack") as Texture;
        playerOneTexture = Resources.Load("Player1") as Texture;
        playerTwoTexture = Resources.Load("Player2") as Texture;
        playerOnePowerTexture = Resources.Load("Player1Power") as Texture;
        PlayerTwoPowerTexture = Resources.Load("Player2Power") as Texture;
        twoPointsTexture = Resources.Load("TwoPoints") as Texture;
        PowerTexture = Resources.Load("PowerLevel") as Texture;
        GUIHeightDivider = 10;
        numberWidthDivider = 15;
        playerIconWidthDivider = 6;
        PlayerPowerIconWidthDivider = 8;

        timer = 300.0f;
        player1PowerLevel = player2PowerLevel = 0;

        numbers.Add(Resources.Load("Zero") as Texture);
        numbers.Add(Resources.Load("One") as Texture);
        numbers.Add(Resources.Load("Two") as Texture);
        numbers.Add(Resources.Load("Three") as Texture);
        numbers.Add(Resources.Load("Four") as Texture);
        numbers.Add(Resources.Load("Five") as Texture);
        numbers.Add(Resources.Load("Six") as Texture);
        numbers.Add(Resources.Load("Seven") as Texture);
        numbers.Add(Resources.Load("Eight") as Texture);
        numbers.Add(Resources.Load("Nine") as Texture);
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;

        if (player1PowerLevel < 100)
            player1PowerLevel = player2PowerLevel += Time.deltaTime;
        else
            player1PowerLevel = player2PowerLevel = 0;

        minutesNumber = Mathf.Floor(timer / 60);
        secondsOneNumber = Mathf.RoundToInt(timer % 60) / 10;
        secondsTwoNumber = Mathf.RoundToInt(timer % 60) - (Mathf.RoundToInt(timer % 60) / 10) * 10;

        //To control not to show a 6 in the wrong digit of seconds
        if (secondsOneNumber == 6)
        {
            minutesNumber += 1;
            secondsOneNumber = 0;
            secondsTwoNumber = 0;
        }
           
        if (timer <= 0)
            timer = 300.0f;
	}

    public void drawGUI()
    {
        GUIHeight = Screen.height / GUIHeightDivider;
        numberWidth = Screen.width / numberWidthDivider;
        playerIconWidth = Screen.width / playerIconWidthDivider;
        playerPowerIconWidth = Screen.width / PlayerPowerIconWidthDivider;

        timerMinutesPosX = Screen.width / 2 - numberWidth / 2 - numberWidth - numberWidth / 10;
        timerSecondsOnePosX = Screen.width / 2 - numberWidth / 2;
        timerSecondsTwoPosX = Screen.width / 2 - numberWidth / 2 + numberWidth;
        twoPointsPosX = Screen.width / 2 - (int)(numberWidth / 1.5);

        powerLevelHeight = (int)(GUIHeight / 1.3);
        powerLevel1PosX = playerIconWidth + 8 + (playerPowerIconWidth / 5) - (playerPowerIconWidth / 8);
        powerLevel2PosX = Screen.width - playerIconWidth - 8 - (playerPowerIconWidth / 5) + (playerPowerIconWidth / 8);
        powerLevelMaxWidth = (int)((playerPowerIconWidth - playerPowerIconWidth / 5));

        //Calculate the width depending on the amount of energy the player stores
        powerLevelOnePercent = (float)powerLevelMaxWidth / 100;
        powerLevel1Width = player1PowerLevel * powerLevelOnePercent;
        powerLevel2Width = -player2PowerLevel * powerLevelOnePercent;


        //GUI.DrawTexture(new Rect(0, 0, Screen.width, GUIHeight), GUIBack);

        //Timer
        GUI.DrawTexture(new Rect(timerMinutesPosX, 0, numberWidth, GUIHeight), numbers[(int)minutesNumber]);
        GUI.DrawTexture(new Rect(timerSecondsOnePosX, 0, numberWidth, GUIHeight), numbers[(int)secondsOneNumber]);
        GUI.DrawTexture(new Rect(timerSecondsTwoPosX, 0, numberWidth, GUIHeight), numbers[(int)secondsTwoNumber]);
        GUI.DrawTexture(new Rect(twoPointsPosX, 0, numberWidth / 3, GUIHeight), twoPointsTexture);

        //Player 1 and 2 icons
        GUI.DrawTexture(new Rect(0, 0, playerIconWidth, GUIHeight), playerOneTexture);
        GUI.DrawTexture(new Rect(Screen.width - playerIconWidth, 0, playerIconWidth, GUIHeight), playerTwoTexture);
       
        //Player Power Level
        GUI.DrawTexture(new Rect(playerIconWidth + 10, 0, playerPowerIconWidth, GUIHeight), playerOnePowerTexture);
        GUI.DrawTexture(new Rect(powerLevel1PosX, GUIHeight / 2 - powerLevelHeight / 2, powerLevel1Width, powerLevelHeight), PowerTexture);
        GUI.DrawTexture(new Rect(Screen.width - playerIconWidth - playerPowerIconWidth - 10, 0, playerPowerIconWidth, GUIHeight), PlayerTwoPowerTexture);
        GUI.DrawTexture(new Rect(powerLevel2PosX, GUIHeight / 2 - powerLevelHeight / 2, powerLevel2Width, powerLevelHeight), PowerTexture);
    }
}
