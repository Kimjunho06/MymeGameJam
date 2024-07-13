using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetVAbility : Ability
{
    private float _addSpeed = 6f;
    
    public override void Init()
    {
    }

    public override void PlayAbility(PlayerController player)
    {
        player.playerMovement.animator.speed = 2f;

        player.playerMovement.moveSpeed = player.DefaultMoveSpeed + _addSpeed;
    }

    public override void ResetAbility(PlayerController player)
    {
        player.playerMovement.animator.speed = 1f;

        player.playerMovement.moveSpeed = player.DefaultMoveSpeed;
    }
}
