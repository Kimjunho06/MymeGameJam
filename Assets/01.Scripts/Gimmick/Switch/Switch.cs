using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool IsPressed;

    protected bool IsPressedSwitch(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Alphabet"))
            return true;

        return false;
    }
}
