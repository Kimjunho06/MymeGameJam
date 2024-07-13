using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool IsPressed;
    public bool IsElectronicSwitch;

    protected PlayerController player;

    protected bool IsPressedSwitch(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") )
        {
            player = collision.collider.GetComponent<PlayerController>();
            return true;
        }
        if (collision.collider.CompareTag("Alphabet"))
        {
            return true;
        }

        return false;
    }

    protected bool IsElectronicSwitchCheck()
    {
        if (IsElectronicSwitch)
        {
            if (player.IsElectronic)
            {
                return true;
            }
        }
        else
            return true;

        return false;
    }
}
