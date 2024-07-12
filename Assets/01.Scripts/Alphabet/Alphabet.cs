using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    public AlphabetSO AlphabetSO;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (AlphabetSO.isCaptialLetter)
            spriteRenderer.sprite = AlphabetSO.capitalLetterSprite;
        else
            spriteRenderer.sprite = AlphabetSO.smallLetterSprite;
    }
}
