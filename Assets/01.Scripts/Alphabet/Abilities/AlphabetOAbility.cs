using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetOAbility : Ability
{
    // �빮�ڸ�.
    public override void PlayAbility(PlayerController player)
    {
        player.IsUnlockable = true;
    }

    // �ҹ��ڸ�.
    public override void ResetAbility(PlayerController player)
    {
        player.IsUnlockable = false;
    }
}
