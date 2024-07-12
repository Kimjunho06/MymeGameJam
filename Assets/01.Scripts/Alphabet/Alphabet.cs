using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    public AlphabetSO AlphabetSO;
    private SpriteRenderer spriteRenderer;

    public Vector3 size;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!AlphabetSO)
        {
            Debug.LogError($"{gameObject.name} : AlphabetSO is Not Found");
        }
    }

    private void Start()
    {
        transform.localScale = size;
    }

    private void Update()
    {
        if (AlphabetSO.isSamllLetter)
            spriteRenderer.sprite = AlphabetSO.capitalLetterSprite;
        else
            spriteRenderer.sprite = AlphabetSO.smallLetterSprite;
    }
}
