using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMechanics : MonoBehaviour {

    Texture GUIBack, playerOneTexture, twoPointsTexture, playerTwoTexture, playerOnePowerTexture, playerTwoPowerTexture, 
            powerTexture, playerOneScore1Texture, playerOneScore2Texture, playerTwoScore1Texture, playerTwoScore2Texture,
            powerRedTexture, powerYellowTexture, powerOrangeTexture, powerLightGreenTexture, powerGreenTexture,
            player1PowerTexture, player2PowerTexture;

    public float minutesNumber, secondsOneNumber, secondsTwoNumber;

    List<Texture> numbers = new List<Texture>();

    int GUIHeight, GUIHeightDivider, numberWidth, numberWidthDivider, playerIconWidth, playerIconWidthDivider,
        timerMinutesPosX, timerSecondsOnePosX, timerSecondsTwoPosX, playerPowerIconWidth, playerPowerIconWidthDivider,
        twoPointsPosX, powerLevelHeight, powerLevel1PosX, powerLevel2PosX, playerOneScore1, playerOneScore2, playerTwoScore1,
        playerTwoScore2, player1IconPosX, player2IconPosX, player1PowerIconPosX, player2PowerIconPosX, playerPowerLevelPosY;

    float playerOneScore1PosX, playerOneScore2PosX, playerOneScore1PosY, playerOneScore2PosY, playerTwoScore1PosX, 
        playerTwoScore2PosX, playerTwoScore1PosY, playerTwoScore2PosY;

    float powerLevelOnePercent;

    public float timer, powerLevel1Width, powerLevel2Width, powerLevelMaxWidth;

    public bool timerStop;

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
        powerRedTexture = Resources.Load("PowerLevelRed") as Texture;
        powerYellowTexture = Resources.Load("PowerLevelYellow") as Texture;
        powerOrangeTexture = Resources.Load("PowerLevelOrange") as Texture;
        powerLightGreenTexture = Resources.Load("PowerLevelLightGreen") as Texture;
        powerGreenTexture = Resources.Load("PowerLevelGreen") as Texture;

        GUIHeightDivider = 10;
        numberWidthDivider = 15;
        playerIconWidthDivider = 10;
        playerPowerIconWidthDivider = 8;

        timer = 300.0f;

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

        player1Stats.powerLevel = player2Stats.powerLevel = 0;

        bool timerStop = false;
    }

    // Update is called once per frame
    void Update () {
        if(!timerStop)
            timer -= Time.deltaTime;

        if (player1Stats.powerLevel < player1Stats.maxPowerLevel)
            player1Stats.powerLevel = player2Stats.powerLevel += Time.deltaTime;
        else
            player1Stats.powerLevel = player2Stats.powerLevel = 0;

        CheckPowerLevel();

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

    void CheckPowerLevel()
    {
        if (player1Stats.powerLevel > 0 && player1Stats.powerLevel <= 20)
            player1PowerTexture = powerRedTexture;
        else if (player1Stats.powerLevel > 20 && player1Stats.powerLevel <= 40)
            player1PowerTexture = powerOrangeTexture;
        else if (player1Stats.powerLevel > 40 && player1Stats.powerLevel <= 60)
            player1PowerTexture = powerYellowTexture;
        else if (player1Stats.powerLevel > 60 && player1Stats.powerLevel <= 80)
            player1PowerTexture = powerLightGreenTexture;
        else if (player1Stats.powerLevel > 80 && player1Stats.powerLevel <= 100)
            player1PowerTexture = powerGreenTexture;

        if (player2Stats.powerLevel > 0 && player2Stats.powerLevel <= 20)
            player2PowerTexture = powerRedTexture;
        else if (player2Stats.powerLevel > 20 && player2Stats.powerLevel <= 40)
            player2PowerTexture = powerOrangeTexture;
        else if (player2Stats.powerLevel > 40 && player2Stats.powerLevel <= 60)
            player2PowerTexture = powerYellowTexture;
        else if (player2Stats.powerLevel > 60 && player2Stats.powerLevel <= 80)
            player2PowerTexture = powerLightGreenTexture;
        else if (player2Stats.powerLevel > 80 && player2Stats.powerLevel <= 100)
            player2PowerTexture = powerGreenTexture;
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

        player1IconPosX = Screen.width / 12;
        player2IconPosX = Screen.width - Screen.width / 6 - Screen.width / 50;
        player1PowerIconPosX = player1IconPosX + playerIconWidth + Screen.width / 30;
        player2PowerIconPosX = player2IconPosX - playerIconWidth - Screen.width / 30;
        powerLevelHeight = GUIHeight / 3;
        playerPowerLevelPosY = powerLevelHeight;
        powerLevel1PosX = player1PowerIconPosX + player1PowerIconPosX / 25;
        powerLevel2PosX = player2PowerIconPosX + playerPowerIconWidth - player2PowerIconPosX / 82;
        powerLevelMaxWidth = (int)((playerPowerIconWidth - playerPowerIconWidth / 5));

        //Set score numbers positions and values
        playerOneScore1PosX = playerIconWidth - numberWidth;
        playerOneScore2PosX = playerIconWidth;
        playerTwoScore2PosX = Screen.width - playerIconWidth;
        playerTwoScore1PosX = Screen.width - playerIconWidth - numberWidth;
        playerOneScore1PosY = GUIHeight * 1.25f;
        playerOneScore2PosY = GUIHeight * 1.25f;
        playerTwoScore1PosY = GUIHeight * 1.25f;
        playerTwoScore2PosY = GUIHeight * 1.25f;

        SetScoreNumbers(); 

        //Calculate the width depending on the amount of energy the player stores
        powerLevelOnePercent = (float)powerLevelMaxWidth / 100;
        powerLevel1Width = player1Stats.powerLevel * powerLevelOnePercent;
        powerLevel2Width = -player2Stats.powerLevel * powerLevelOnePercent;


        GUI.DrawTexture(new Rect(0, 0, Screen.width, GUIHeight), GUIBack);

        //Timer
        GUI.DrawTexture(new Rect(timerMinutesPosX, GUIHeight / 4, numberWidth, GUIHeight / 2), numbers[(int)minutesNumber]);
        GUI.DrawTexture(new Rect(timerSecondsOnePosX, GUIHeight / 4, numberWidth, GUIHeight / 2), numbers[(int)secondsOneNumber]);
        GUI.DrawTexture(new Rect(timerSecondsTwoPosX, GUIHeight / 4, numberWidth, GUIHeight / 2), numbers[(int)secondsTwoNumber]);
        GUI.DrawTexture(new Rect(twoPointsPosX, GUIHeight / 4, numberWidth / 3, GUIHeight / 2), twoPointsTexture);

        //Player 1 and 2 icons
        GUI.DrawTexture(new Rect(player1IconPosX, GUIHeight / 4, playerIconWidth, GUIHeight / 2), playerOneTexture);
        GUI.DrawTexture(new Rect(player2IconPosX, GUIHeight / 4, playerIconWidth, GUIHeight / 2), playerTwoTexture);
       
        //Player Power Level
        GUI.DrawTexture(new Rect(player1PowerIconPosX, GUIHeight / 6, playerPowerIconWidth, GUIHeight / 1.5f), playerOnePowerTexture);
        GUI.DrawTexture(new Rect(powerLevel1PosX, playerPowerLevelPosY, powerLevel1Width, powerLevelHeight), player1PowerTexture);
        GUI.DrawTexture(new Rect(player2PowerIconPosX, GUIHeight / 6, playerPowerIconWidth, GUIHeight / 1.5f), playerTwoPowerTexture);
        GUI.DrawTexture(new Rect(powerLevel2PosX, playerPowerLevelPosY, powerLevel2Width, powerLevelHeight), player2PowerTexture);

        //Player Score
        GUI.DrawTexture(new Rect(playerOneScore1PosX, playerOneScore1PosY, numberWidth, GUIHeight), numbers[playerOneScore1]);
        GUI.DrawTexture(new Rect(playerOneScore2PosX, playerOneScore2PosY, numberWidth, GUIHeight), numbers[playerOneScore2]);
        GUI.DrawTexture(new Rect(playerTwoScore1PosX, playerTwoScore1PosY, numberWidth, GUIHeight), numbers[playerTwoScore1]);
        GUI.DrawTexture(new Rect(playerTwoScore2PosX, playerTwoScore2PosY, numberWidth, GUIHeight), numbers[playerTwoScore2]);
    }
}
