using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MultySwitchState
{
    None,
    Keep,
    Touch
}

public class MultySwitch : Switch
{
    public MultySwitchState state = MultySwitchState.None;

    public MultySwitch[] switches;
    public bool IsPress;

    private void Start()
    {
        if (state == MultySwitchState.None)
        {
            Debug.LogError($"{gameObject.name} : Multy Switch State is not Define");
        }
    }

    private void Update()
    {
        foreach (var sw in switches)
        {
            if (!IsPress) return;
        }
        IsPressed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsPress = IsPressedSwitch(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (state == MultySwitchState.Touch)
        {
            IsPress = false;
        }
    }
}
