using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSwitch : Switch
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

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
