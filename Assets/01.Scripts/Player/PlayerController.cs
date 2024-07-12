using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerAlphabet alphabet;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        alphabet = GetComponent<PlayerAlphabet>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            alphabet.PickUp();    
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (alphabet.IsPickUp)
                alphabet.pickUpAlphabet.AlphabetSO.CaseChange();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!alphabet.pickUpAlphabet) return;

            alphabet.RotateAlphabet();
        }
    }
}
