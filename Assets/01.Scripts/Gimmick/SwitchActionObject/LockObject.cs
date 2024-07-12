using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : MonoBehaviour
{
    public bool IsLock = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            if (playerController.IsUnlockable)
            {
                IsLock = true;
            }
        }
    }
}
