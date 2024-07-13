using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSwitch : Switch
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
}
