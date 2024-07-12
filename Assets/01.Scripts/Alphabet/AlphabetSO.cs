using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Alphabet")]
public class AlphabetSO : ScriptableObject
{
    public Sprite capitalLetterSprite;
    public Sprite smallLetterSprite;

    public bool isCaptialLetter;

    public void CaseChange()
    {
        isCaptialLetter = !isCaptialLetter;   
    }
}
