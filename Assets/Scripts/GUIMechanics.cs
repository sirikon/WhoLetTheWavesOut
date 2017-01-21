using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMechanics : MonoBehaviour {

    Texture GUIBack, playerOneTexture, twoPointsTexture, playerTwoTexture, playerOnePowerTexture, playerTwoPowerTexture, 
            powerTexture, playerOneScore1Texture, playerOneScore2Texture, playerTwoScore1Texture, playerTwoScore2Texture;
    public float minutesNumber, secondsOneNumber, secondsTwoNumber;

    List<Texture> numbers = new List<Texture>();

    int GUIHeight, GUIHeightDivider, numberWidth, numberWidthDivider, playerIconWidth, playerIconWidthDivider,
        timerMinutesPosX, timerSecondsOnePosX, timerSecondsTwoPosX, playerPowerIconWidth, playerPowerIconWidthDivider,
        twoPointsPosX, powerLevelHeight, powerLevel1PosX, powerLevel2PosX, playerOneScore1, playerOneScore2, playerTwoScore1,
        playerTwoScore2;

    float playerOneScore1PosX, playerOneScore2PosX, playerOneScore1PosY, playerOneScore2PosY, playerTwoScore1PosX, 
        playerTwoScore2PosX, playerTwoScore1PosY, playerTwoScore2PosY;

    float powerLevelOnePercent;

    public float timer, player1PowerLevel, player2PowerLevel, powerLevel1Width, powerLevel2Width, powerLevelMaxWidth;

    GameObject player1, player2;
    PlayerStats player1Stats, player2Stats;

	// Use this for initialization
	void Start () {
        GUIBack = Resources.Load("GUIBack") as Texture;
        playerOneTexture = Resources.Load("Player1") as Texture;
        playerTwoTexture = Resources.Load("Player2") as Texture;
        playerOnePowerTexture = Resources.Load("Player1Power") as Texture;
        playerTwoPowerTexture = Resources.Load("Player2Power") as Texture;
        twoPointsTexture = Resources.Load("TwoPoints") as Texture;
        powerTexture = Resources.Load("PowerLevel") as Texture;
        GUIHeightDivider = 10;
        numberWidthDivider = 15;
        playerIconWidthDivider = 6;
        playerPowerIconWidthDivider = 8;

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

        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player1Stats = player1.GetComponent<PlayerStats>();
        player2Stats = player2.GetComponent<PlayerStats>();
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

        if (minutesNumber < 0)
            minutesNumber = 0;
           
        if (timer <= 0)
            timer = 0.0f;
	}

    void SetScoreNumbers()
    {
        playerOneScore1 = player1Stats.playerScore / 10;
        playerOneScore2 = player1Stats.playerScore - ((player1Stats.playerScore / 10) * 10);
        playerTwoScore1 = player2Stats.playerScore / 10;
        playerTwoScore2 = player2Stats.playerScore - ((player2Stats.playerScore / 10) * 10);
    }

    public void drawGUI()
    {
        GUIHeight = Screen.height / GUIHeightDivider;
        numberWidth = Screen.width / numberWidthDivider;
        playerIconWidth = Screen.width / playerIconWidthDivider;
        playerPowerIconWidth = Screen.width / playerPowerIconWidthDivider;

        timerMinutesPosX = Screen.width / 2 - numberWidth / 2 - numberWidth - numberWidth / 10;
        timerSecondsOnePosX = Screen.width / 2 - numberWidth / 2;
        timerSecondsTwoPosX = Screen.width / 2 - numberWidth / 2 + numberWidth;
        twoPointsPosX = Screen.width / 2 - (int)(numberWidth / 1.5);

        powerLevelHeight = (int)(GUIHeight / 1.3);
        powerLevel1PosX = playerIconWidth + 8 + (playerPowerIconWidth / 5) - (playerPowerIconWidth / 8);
        powerLevel2PosX = Screen.width - playerIconWidth - 8 - (playerPowerIconWidth / 5) + (playerPowerIconWidth / 8);
        powerLevelMaxWidth = (int)((playerPowerIconWidth - playerPowerIconWidth / 5));

        //Set score numbers positions and values
        playerOneScore1PosX = playerIconWidth / 2 - numberWidth;
        playerOneScore2PosX = playerIconWidth / 2;
        playerTwoScore2PosX = Screen.width - playerIconWidth / 2;
        playerTwoScore1PosX = Screen.width - playerIconWidth / 2 - numberWidth;
        playerOneScore1PosY = GUIHeight * 1.25f;
        playerOneScore2PosY = GUIHeight * 1.25f;
        playerTwoScore1PosY = GUIHeight * 1.25f;
        playerTwoScore2PosY = GUIHeight * 1.25f;

        SetScoreNumbers(); 

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
        GUI.DrawTexture(new Rect(powerLevel1PosX, GUIHeight / 2 - powerLevelHeight / 2, powerLevel1Width, powerLevelHeight), powerTexture);
        GUI.DrawTexture(new Rect(Screen.width - playerIconWidth - playerPowerIconWidth - 10, 0, playerPowerIconWidth, GUIHeight), playerTwoPowerTexture);
        GUI.DrawTexture(new Rect(powerLevel2PosX, GUIHeight / 2 - powerLevelHeight / 2, powerLevel2Width, powerLevelHeight), powerTexture);

        //Player Score
        GUI.DrawTexture(new Rect(playerOneScore1PosX, playerOneScore1PosY, numberWidth, GUIHeight), numbers[playerOneScore1]);
        GUI.DrawTexture(new Rect(playerOneScore2PosX, playerOneScore2PosY, numberWidth, GUIHeight), numbers[playerOneScore2]);
        GUI.DrawTexture(new Rect(playerTwoScore1PosX, playerTwoScore1PosY, numberWidth, GUIHeight), numbers[playerTwoScore1]);
        GUI.DrawTexture(new Rect(playerTwoScore2PosX, playerTwoScore2PosY, numberWidth, GUIHeight), numbers[playerTwoScore2]);
    }
}
