using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwitchActionObject : MonoBehaviour
{
    public Switch[] needSwitch;

    private void Update()
    {
        if (needSwitch != null)
        {
            foreach (var sw in needSwitch)
            {
                if (!sw.IsPressed)
                {
                    ResetAction();
                    return;
                } 

            }
        }
        InvokeAction();
    }

    protected abstract void InvokeAction();
    protected abstract void ResetAction();
}
