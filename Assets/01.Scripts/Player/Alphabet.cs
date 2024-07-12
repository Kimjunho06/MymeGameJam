using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    public bool IsPickUp;

    public void PickUp()
    {
        if (IsPickAble())
        {
            IsPickUp = !IsPickUp;


        }
    }

    private bool IsPickAble()
    {
        // Overlap2D
        return true;
    }
}
