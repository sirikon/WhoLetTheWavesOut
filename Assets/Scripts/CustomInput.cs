using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomInput {
    public static bool GetButton(CustomInputButton button, int playerNumber = 0)
    {
        bool result = false;

        switch(button)
        {
            case CustomInputButton.TowerBottomLeft:
                result = Input.GetButton("x360 Bumper Left " + playerNumber);
                break;
            case CustomInputButton.TowerBottomRight:
                result = Input.GetButton("x360 Bumper Right " + playerNumber);
                break;
            case CustomInputButton.TowerTopLeft:
                result = Input.GetAxis("x360 Trigger Left " + playerNumber) >= 0.2;
                break;
            case CustomInputButton.TowerTopRight:
                result = Input.GetAxis("x360 Trigger Right " + playerNumber) >= 0.2;
                break;
            case CustomInputButton.PlayerAction:
                result = Input.GetButton("x360 A " + playerNumber);
                break;
        }

        return result;
    }
}

public enum CustomInputButton
{
    TowerTopRight,
    TowerTopLeft,
    TowerBottomRight,
    TowerBottomLeft,
    PlayerAction,
}
