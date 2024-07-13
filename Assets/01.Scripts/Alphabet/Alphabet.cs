using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    public AlphabetSO AlphabetSO;
    private SpriteRenderer spriteRenderer;

    public Vector3 size;

    public bool changeCollider = false;

    public LayerMask whatIsWall;

    public Vector2[] ePoints;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!AlphabetSO)
        {
            Debug.LogError($"{gameObject.name} : AlphabetSO is Not Found");
        }
    }

    private void Start()
    {
        if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid)) { }
        if (TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider)) { }
        if (AlphabetSO.alphabetType == AlphabetType.M)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (AlphabetSO.alphabetType == AlphabetType.V)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (AlphabetSO.alphabetType == AlphabetType.E)
        {
            ePoints = collider.points;
        }

        transform.localScale = size;
        changeCollider = true;
    }

    private void Update()
    {
        if (!AlphabetSO.isSamllLetter)
        {
            spriteRenderer.sprite = AlphabetSO.capitalLetterSprite;
        }
        else
        {
            spriteRenderer.sprite = AlphabetSO.smallLetterSprite;
        }

        if (changeCollider)
        {
            changeCollider = false;
            if (transform.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider))
            {
                Destroy(collider);
            }
            PolygonCollider2D col = gameObject.AddComponent<PolygonCollider2D>();

            if (!AlphabetSO.isSamllLetter)
            {
                if (AlphabetSO.alphabetType == AlphabetType.E)
                {
                    col.points = ePoints;
                    collider.points = ePoints;
                }
            }
        }

        if (GameManager.Instance.PlayerInstance.alphabet.IsPickUp)
        {
            //float xinput = GameManager.Instance.PlayerInstance.playerMovement.XInput;
            //float yinput = GameManager.Instance.PlayerInstance.playerMovement.YInput;

            CheckWidthWall();
            CheckHeightWall();
            //
            //if (Mathf.Abs(xinput) > 0.05f)
            //{
            //    CheckWidthWall();
            //}
            //else
            //{
            //    CheckHeightWall();
            //}
        }
        else
        {
            GameManager.Instance.PlayerInstance.playerMovement.moveSpeed = GameManager.Instance.PlayerInstance.DefaultMoveSpeed;
        }
    }

    private void CheckWidthWall()
    {
        Debug.Log("A");
        float lookDir = GameManager.Instance.PlayerInstance.playerMovement.playerLookDir;
        if (transform.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider)){}

        Vector3 startPosUpper = new Vector2(transform.position.x, collider.bounds.max.y);
        Vector3 startPosMiddle = new Vector2(transform.position.x, transform.position.y);
        Vector3 startPosLower = new Vector2(transform.position.x, collider.bounds.min.y);
        List<RaycastHit2D> hits = new List<RaycastHit2D>
        {
            Physics2D.Raycast(startPosUpper, lookDir * Vector2.right, size.x / 2 * ( 3f / 4f), whatIsWall),
            Physics2D.Raycast(startPosMiddle, lookDir * Vector2.right, size.x / 2 * (3f / 4f), whatIsWall),
            Physics2D.Raycast(startPosLower, lookDir * Vector2.right, size.x / 2 * ( 3f / 4f), whatIsWall)
        };
        
        Debug.DrawRay(startPosUpper, lookDir * Vector2.right * (size.x / 2 * ( 3f / 4f)));
        Debug.DrawRay(startPosMiddle, lookDir * Vector2.right * (size.x / 2 * (3f / 4f)));
        Debug.DrawRay(startPosLower, lookDir * Vector2.right * (size.x / 2 * ( 3f / 4f)));

        foreach (RaycastHit2D hit in hits)
        {
            if (hit)
            {
                GameManager.Instance.PlayerInstance.playerMovement.moveSpeed = 0;
                return;
            }
        }

        if (GameManager.Instance.PlayerInstance.playerMovement.IsGroundDetect())
        {
            GameManager.Instance.PlayerInstance.playerMovement.moveSpeed = GameManager.Instance.PlayerInstance.DefaultMoveSpeed;
        }
        if (Mathf.Abs(GameManager.Instance.PlayerInstance.playerMovement.XInput) < 0.05f && Mathf.Abs(GameManager.Instance.PlayerInstance.playerMovement.YInput) < 0.05f)
        {
            GameManager.Instance.PlayerInstance.playerMovement.moveSpeed = GameManager.Instance.PlayerInstance.DefaultMoveSpeed;
        }
    }

    private void CheckHeightWall()
    {
        if (transform.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider)) { }

        Vector3 startPosRight = new Vector2(collider.bounds.max.x - (size.x * 0.1f), transform.position.y);
        Vector3 startPosMiddle = new Vector2(transform.position.x, transform.position.y);
        Vector3 startPosLeft = new Vector2(collider.bounds.min.x + (size.x * 0.1f), transform.position.y);
        List<RaycastHit2D> hits = new List<RaycastHit2D>
        {
            Physics2D.Raycast(startPosRight, Vector2.up, size.y / 2 * ( 9f /  10f), whatIsWall),
            Physics2D.Raycast(startPosMiddle, Vector2.up, size.y / 2 * (9f /  10f), whatIsWall),
            Physics2D.Raycast(startPosLeft, Vector2.up, size.y / 2 * (  9f /  10f), whatIsWall)
        };

        Debug.DrawRay(startPosRight, Vector2.up * (size.y / 2 * ( 9f / 10f)));
        Debug.DrawRay(startPosMiddle, Vector2.up * (size.y / 2 * (9f / 10f)));
        Debug.DrawRay(startPosLeft, Vector2.up * (size.y / 2 * (  9f / 10f)));

        

        foreach (RaycastHit2D hit in hits)
        {            
            if (hit)
            {
                GameManager.Instance.PlayerInstance.alphabet.pickUpPos.y -= 10 * Time.deltaTime;
                return;
            }
        }
        GameManager.Instance.PlayerInstance.alphabet.pickUpPos = Vector3.Lerp(GameManager.Instance.PlayerInstance.alphabet.pickUpPos, GameManager.Instance.PlayerInstance.DefaultPickUpPos, Time.deltaTime * 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Balloon"))
        {
            if (AlphabetSO.alphabetType == AlphabetType.V)
            {
                if (collision.transform.position.x < transform.position.x) // 왼쪽에 있을 때
                {
                    if (GameManager.Instance.PlayerInstance.alphabet.pickUpAlphabetRotation == 270) // left <
                    {
                        Destroy(collision.gameObject);
                    }
                }
                else
                {
                    if (GameManager.Instance.PlayerInstance.alphabet.pickUpAlphabetRotation == 90) // right >
                    {
                        Destroy(collision.gameObject);
                    }
                }

                if (collision.transform.position.y < transform.position.y)
                {
                    if (GameManager.Instance.PlayerInstance.alphabet.pickUpAlphabetRotation == 0) // right >
                    {
                        Destroy(collision.gameObject);
                    }
                }

            }
        }   
    }
}
