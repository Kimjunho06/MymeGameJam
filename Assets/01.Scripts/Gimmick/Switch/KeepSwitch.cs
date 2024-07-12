using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSwitch : Switch
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsElectronicSwitchCheck()) return;

        IsPressed = IsPressedSwitch(collision);
    }
}
