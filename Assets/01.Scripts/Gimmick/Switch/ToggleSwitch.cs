using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : Switch
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPressedSwitch(collision))
        {
            IsPressed = !IsPressed;
        }
    }
}
