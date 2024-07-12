using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Alphabet alphabet;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        alphabet = GetComponent<Alphabet>();
    }

    private void Update()
    {
        if (alphabet.IsPickUp)
        {
            if (playerMovement.IsMoved)
            {

            }
        }
        else
        {

        }
    }

    public bool IsGroundDetect()
    {
        return true;
    }
}
