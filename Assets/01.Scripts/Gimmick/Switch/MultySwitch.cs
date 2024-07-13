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

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        if (state == MultySwitchState.None)
        {
            Debug.LogError($"{gameObject.name} : Multy Switch State is not Define");
        }
    }

    protected override void Update()
    {
        base.Update();
        foreach (var sw in switches)
        {
            if (!sw.IsPress) return;
        }
        IsPressed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsElectronicSwitchCheck()) return;

        IsPress = IsPressedSwitch(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (state == MultySwitchState.Touch)
        {
            IsPress = false;
            IsPressed = false;
        }
    }
}
