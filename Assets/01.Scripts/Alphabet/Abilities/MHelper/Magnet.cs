using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetRadius = 5f;
    public float magnetPower = 3f;

    public float attatchDist = 1f;

    public LayerMask whatIsPlayer;

    public bool IsBoxCheck;
    public Vector2 boxCheckSize;

    public bool IsPlayerCheck()
    {
        Collider2D alphabetObj;
        if (!IsBoxCheck)
             alphabetObj = Physics2D.OverlapCircle(transform.position, magnetRadius, whatIsPlayer);
        else
             alphabetObj = Physics2D.OverlapBox(transform.position, boxCheckSize, 0, whatIsPlayer);

        if (alphabetObj == null)
            return false;

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (!IsBoxCheck)
            Gizmos.DrawWireSphere(transform.position, magnetRadius);
        else
            Gizmos.DrawWireCube(transform.position, boxCheckSize);
    }
}
