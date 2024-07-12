using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextStageButton : MonoBehaviour
{
    public UnityEvent NextStageEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
            NextStageEvent?.Invoke();
        
    }
}
