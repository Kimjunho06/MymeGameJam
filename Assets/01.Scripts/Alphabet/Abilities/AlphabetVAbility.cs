using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetVAbility : Ability
{
    private float _addSpeed = 2f;
    
    public override void Init()
    {
    }

    public override void PlayAbility(PlayerController player)
    {
        player.playerMovement.moveSpeed = player.DefaultMoveSpeed + _addSpeed;
    }

    public override void ResetAbility(PlayerController player)
    {
        player.playerMovement.moveSpeed = player.DefaultMoveSpeed;
    }
}
