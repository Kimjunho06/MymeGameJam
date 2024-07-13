using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setting Parameters")]
    public float moveSpeed = 5f;
    public float jumpPower = 3f;
    public float groundCheckDistance = 0.6f;
    public float wallCheckDistance = 0.6f;

    public float wallSlideMultiplier = 0.7f;

    [Header("Develop Parameters")]
    public float XInput;
    public float YInput;

    public int playerLookDir = 1;

    public bool IsMoved { get; private set; }
    private bool IsJump;

    public LayerMask whatIsGround;
    public LayerMask whatIsWall;

    public Rigidbody2D rb;

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        WallSlide();
        rb.velocity += new Vector2(0, -9.8f) * Time.fixedDeltaTime;
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

        Vector3 scale = transform.localScale;
        scale.x = playerLookDir;

        transform.localScale = scale;

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

    private void WallSlide()
    {
        if (IsWallDetect())
        {
            Vector3 pos = rb.velocity;
            pos.y *= wallSlideMultiplier;

            rb.velocity = pos;
        }
    }

    private void MoveAnimation()
    {
        animator.SetBool("IsMove", (Mathf.Abs(XInput) > 0.05f));
    }

    public bool IsGroundDetect()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);

        return hit;
    }

    public bool IsWallDetect()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, whatIsWall);
        Debug.DrawRay(transform.position, Vector2.right * wallCheckDistance, Color.red);

        return hit;
    }
}
