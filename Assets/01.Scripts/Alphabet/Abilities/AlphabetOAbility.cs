using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetOAbility : Ability
{
    // 대문자면.
    public override void PlayAbility(PlayerController player)
    {
        player.IsUnlockable = true;
    }

    // 소문자면.
    public override void ResetAbility(PlayerController player)
    {
        player.IsUnlockable = false;
    }
}
