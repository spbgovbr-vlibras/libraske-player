using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static int GetVerticalAxisRaw()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            return 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            return -1;
        return 0;
    }

    public static int GetHorizontalAxisRaw()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            return 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            return -1;
        return 0;
    }

    public static bool GetHorizontalUp()
    {
        return (
                    Input.GetKeyUp(KeyCode.A) ||
                    Input.GetKeyUp(KeyCode.S) ||
                    Input.GetKeyUp(KeyCode.LeftArrow) ||
                    Input.GetKeyUp(KeyCode.RightArrow)
               );
    }

    public static bool GetHorizontalDown()
    {
        return (
                    Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.S) ||
                    Input.GetKeyDown(KeyCode.LeftArrow) ||
                    Input.GetKeyDown(KeyCode.RightArrow)
               );
    }

    public static bool GetVerticalUp()
    {
        return (
                    Input.GetKeyUp(KeyCode.W) ||
                    Input.GetKeyUp(KeyCode.UpArrow) ||
                    Input.GetKeyUp(KeyCode.DownArrow) ||
                    Input.GetKeyUp(KeyCode.S)
               );
    }

    public static bool GetVerticalDown()
    {
        return (
                    Input.GetKeyDown(KeyCode.W) ||
                    Input.GetKeyDown(KeyCode.UpArrow) ||
                    Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.S)
               );
    }
}