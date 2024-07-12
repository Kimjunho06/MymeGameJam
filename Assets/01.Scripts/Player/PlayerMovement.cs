using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setting Parameters")]
    public float moveSpeed = 5f;

    private float XInput;
    private float YInput;
    public bool IsMoved { get; private set; }

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        XInput = Input.GetAxis("Horizontal");
        YInput = Input.GetAxis("Vertical");

        MoveAnimation();
    }

    private void FixedUpdate()
    {
        IsMoved = (Mathf.Abs(XInput) > 0.05f || Mathf.Abs(YInput) > 0.05f) ? true : false;

        if (Mathf.Abs(XInput) > 0.05f)
        {
            Move();
        }
        if (Mathf.Abs(YInput) > 0.05f)
        {
            Jump();
        }          
    }

    private void Move()
    {
        Vector2 moveDir = new Vector2(XInput, 0);
        moveDir *= moveSpeed;

        rb.velocity = moveDir;
    }

    private void Jump()
    {
        if (true)
        {
            // Jump Action
        }
    }

    private void MoveAnimation()
    {

    }
}
