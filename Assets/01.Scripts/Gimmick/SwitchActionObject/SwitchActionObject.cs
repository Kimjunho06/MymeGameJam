using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwitchActionObject : MonoBehaviour
{
    public Switch[] needSwitch;

    private void Update()
    {
        foreach (var sw in needSwitch)
        {
            if (!sw.IsPressed) 
                return;

        }
        InvokeAction();
    }

    protected abstract void InvokeAction();
}
