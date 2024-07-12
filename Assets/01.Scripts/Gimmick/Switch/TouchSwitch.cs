using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSwitch : Switch
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsPressed = IsPressedSwitch(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsPressed = false;
    }
}
