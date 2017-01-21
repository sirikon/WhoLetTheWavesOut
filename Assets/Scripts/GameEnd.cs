using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour {

    public int scoreToWin;
    float delayTime;

    GameObject player1, player2;
    PlayerStats player1Stats, player2Stats;
    GUIMechanics GUIValues;
    LoadingMechanic loadingMech;

    Texture Player1WinTexture, Player2WinTexture;

    bool player1Win, player2Win, gameEnd;

    // Use this for initialization
    void Start () {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player1Stats = player1.GetComponent<PlayerStats>();
        player2Stats = player2.GetComponent<PlayerStats>();
        GUIValues = GetComponent<GUIMechanics>();
        loadingMech = GetComponent<LoadingMechanic>();

        Player1WinTexture = Resources.Load("Player1Win") as Texture;
        Player2WinTexture = Resources.Load("Player2Win") as Texture;

        player1Win = player2Win = gameEnd = false;

        delayTime = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (!gameEnd)
            CheckIfGameEnd();
        else if (delayTime <= 2)
            delayTime += Time.deltaTime;
        else if(delayTime > 2)
            loadingMech.SetNextScene("GameEnd");
    }

    void CheckIfGameEnd()
    {
        if (player1Stats.playerScore == scoreToWin)
            Player1Win();
        else if (player2Stats.playerScore == scoreToWin)
            Player2Win();
        else if (GUIValues.timer == 0)
            Debug.Log("Time Up");
    }

    void ResetGame()
    {

    }

    void Player1Win()
    {
        player1Win = true;
        gameEnd = true;
    }

    void Player2Win()
    {
        player2Win = true;
        gameEnd = true;
    }

    void OnGUI()
    {
        if(player1Win && delayTime <= 2)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Player1WinTexture);
        if (player2Win && delayTime <= 2)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Player2WinTexture);
    }
}
