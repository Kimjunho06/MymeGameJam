using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSwitch : Switch
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsElectronicSwitchCheck()) return;
        IsPressed = IsPressedSwitch(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsPressed = false;
    }
}
