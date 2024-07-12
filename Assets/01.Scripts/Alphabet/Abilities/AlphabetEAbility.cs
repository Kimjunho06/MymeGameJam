using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetEAbility : Ability
{ 
    public override void PlayAbility(PlayerController player)
    {
        player.IsElectronic = true;
    }

    public override void ResetAbility(PlayerController player)
    {
        player.IsElectronic = false;
    }
}
