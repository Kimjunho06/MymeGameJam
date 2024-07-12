using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AlphabetType
{
    M,
    O,
    V,
    E
}

[CreateAssetMenu(menuName = "SO/Data/Alphabet")]
public class AlphabetSO : ScriptableObject
{
    public Sprite capitalLetterSprite;
    public Sprite smallLetterSprite;
    public AlphabetType alphabetType;

    public bool isSamllLetter;

    public void CaseChange()
    {
        isSamllLetter = !isSamllLetter;   
    }
}
