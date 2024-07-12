using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextStageButton : MonoBehaviour
{
    public LockObject[] lockObjs;

    public UnityEvent NextStageEvent;

    private void Start()
    {
        lockObjs = GameObject.FindObjectsOfType<LockObject>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var obj in lockObjs)
        {
            if (!obj.IsLock) return;
        }

        if (collision.collider.CompareTag("Player"))
            NextStageEvent?.Invoke();
    }
}
