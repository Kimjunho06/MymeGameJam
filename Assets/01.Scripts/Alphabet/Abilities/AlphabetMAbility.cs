using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetMAbility : Ability
{
    private List<Magnet> magnets = new List<Magnet>();
    public override void Init()
    {
        base.Init();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Magnet");
        foreach (var magnet in objs)
        {
            if (magnet.TryGetComponent<Magnet>(out Magnet magnetCompo))
            {
                magnets.Add(magnetCompo);
            }
        }
    }

    // Update
    public override void PlayAbility(PlayerController player)
    {
        foreach (Magnet magnet in magnets)
        {
            if (magnet.IsPlayerCheck())
            {
                Vector3 playerDir = player.playerMovement.rb.velocity;
                Vector3 moveDir = (magnet.transform.position - player.alphabet.pickUpAlphabet.transform.position).normalized;
                
                float dist = Vector2.Distance(player.alphabet.pickUpAlphabet.transform.position, magnet.transform.position);
                
                float magnetPower = magnet.magnetPower;
                
                Vector2 result = playerDir + moveDir;

                if (magnet.IsBoxCheck)
                {
                    if (player.alphabet.pickUpAlphabet.transform.position.y >= magnet.transform.position.y - magnet.attatchDist)
                    {
                        player.playerMovement.rb.velocity = Vector2.zero;
                        return;
                    }

                    Vector2 playerPos = player.playerMovement.rb.velocity;
                    result.x = 0;
                    playerPos.x = 0;
    
    
                    player.playerMovement.rb.velocity = Vector2.Lerp(playerPos, result, 0.1f * magnetPower);
                }
                else
                {
                    if (dist < magnet.attatchDist)
                    {
                        player.playerMovement.rb.velocity = Vector2.zero;
                        return;
                    }


                    player.playerMovement.rb.velocity = Vector2.Lerp(player.playerMovement.rb.velocity, result, 0.1f * magnetPower);
                }
                
                
            }
        }
    }

    public override void ResetAbility(PlayerController player)
    {

    }
}
