using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public abstract void PlayAbility(PlayerController player);
    public abstract void ResetAbility(PlayerController player);

    public virtual void Init()
    {

    }

}
