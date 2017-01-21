using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMechanics : MonoBehaviour {

    Texture GUIBack, secondsOne, secondsTwo, minutes;
    List<Texture> numbers = new List<Texture>();
    int GUIHeight, GUIHeightDivider, numberWidth, numberWidthDivider, numberPosX;

    float timer;

	// Use this for initialization
	void Start () {
        GUIBack = Resources.Load("GUIBack") as Texture;
        GUIHeightDivider = 8;
        numberWidthDivider = 10;

        timer = 9.9f;

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

        if(timer <= 0)
            timer = 9.9f;
	}

    public void drawGUI()
    {
        GUIHeight = Screen.height / GUIHeightDivider;
        numberWidth = Screen.width / numberWidthDivider;

        numberPosX = Screen.width / 2 - numberWidth / 2;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, GUIHeight), GUIBack);

        GUI.DrawTexture(new Rect(100, 0, numberWidth, GUIHeight), numbers[(int)timer]);
    }
}
