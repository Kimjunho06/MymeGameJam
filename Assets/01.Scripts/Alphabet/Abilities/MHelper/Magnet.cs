using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetRadius = 5f;
    public float magnetPower = 3f;

    public LayerMask whatIsPlayer;

    public bool IsPlayerCheck()
    {
        Collider2D alphabetObj = Physics2D.OverlapCircle(transform.position, magnetRadius, whatIsPlayer);
        if (alphabetObj == null)
            return false;

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
