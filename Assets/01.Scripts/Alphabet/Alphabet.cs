using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    public AlphabetSO AlphabetSO;
    private SpriteRenderer spriteRenderer;

    public Vector3 size;

    public bool changeCollider = true;

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
        if (!AlphabetSO.isSamllLetter)
        {
            spriteRenderer.sprite = AlphabetSO.capitalLetterSprite;
        }
        else
        {
            spriteRenderer.sprite = AlphabetSO.smallLetterSprite;
        }

        if (changeCollider)
        {
            changeCollider = false;
            if (transform.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider))
            {
                Destroy(collider);
            }
            gameObject.AddComponent<PolygonCollider2D>();
        }
        
    }
}
