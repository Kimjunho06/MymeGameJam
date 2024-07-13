using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerAlphabet alphabet;
    public PlayerAlphabetAbility ability;

    public float DefaultMoveSpeed;

    public Vector2 DefaultPickUpPos;

    public bool IsUnlockable;
    public bool IsElectronic;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        alphabet = GetComponent<PlayerAlphabet>();
        ability = GetComponent<PlayerAlphabetAbility>();

        if (!playerMovement)
            Debug.LogError("Player Not Contain PlayerMovement");
        if (!alphabet)
            Debug.LogError("Player Not Contain PlayerAlphabet");
        if (!ability)
            Debug.LogError("Player Not Contain PlayerAlphabetAbility");
    }

    private void Start()
    {
        DefaultMoveSpeed = playerMovement.moveSpeed;
        DefaultPickUpPos = alphabet.pickUpPos;
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
            {
                alphabet.pickUpAlphabet.AlphabetSO.CaseChange();
                alphabet.pickUpAlphabet.changeCollider = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!alphabet.pickUpAlphabet) return;

            alphabet.RotateAlphabet();
        }

        if (alphabet.pickUpAlphabet)
        {
            if (!alphabet.pickUpAlphabet.AlphabetSO.isSamllLetter)
            {
                ability.InvokeAbility(alphabet.pickUpAlphabet.AlphabetSO);
            }
            else
            {
                ability.ResetAbility(alphabet.pickUpAlphabet.AlphabetSO);
            }
        }
    }
}
