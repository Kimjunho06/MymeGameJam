using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setting Parameters")]
    public float moveSpeed = 5f;
    public float jumpPower = 3f;
    public float groundCheckDistance = 0.6f;

    [Header("Develop Parameters")]
    private float XInput;
    private float YInput;

    public int playerLookDir = 1;

    public bool IsMoved { get; private set; }
    private bool IsJump;

    public LayerMask whatIsGround;

    private Rigidbody2D rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        XInput = Input.GetAxis("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");

        MoveAnimation();

        if (IsGroundDetect())
        {
            if (rb.velocity.y > 0) return;
            IsJump = false;
        }
    }

    private void FixedUpdate()
    {
        IsMoved = (Mathf.Abs(XInput) > 0.05f || YInput > 0.05f) ? true : false;

        if (Mathf.Abs(XInput) > 0.05f)
        {
            Move();
        }
        if (YInput > 0.05f)
        {
            Jump();
        }          
    }

    private void Move()
    {
        if (XInput > 0f)
            playerLookDir = 1;
        else if (XInput < 0f)
            playerLookDir = -1;

        Vector2 moveDir = new Vector2(XInput, 0);
        moveDir *= moveSpeed;
        moveDir.y = rb.velocity.y;

        rb.velocity = moveDir;
    }

    private void Jump()
    {
        if (IsGroundDetect())
        {
            if (IsJump) return;
            if (rb.velocity.y > 0) return;
            IsJump = true;

            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void MoveAnimation()
    {

    }

    public bool IsGroundDetect()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);

        return hit;
    }

    
}
