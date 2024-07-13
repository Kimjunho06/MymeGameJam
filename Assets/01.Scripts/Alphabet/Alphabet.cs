using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    public AlphabetSO AlphabetSO;
    private SpriteRenderer spriteRenderer;

    public Vector3 size;

    public bool changeCollider = true;

    public LayerMask whatIsWall;

    private bool IsWidthLimit;

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
        transform.localScale = size;
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
            gameObject.AddComponent<PolygonCollider2D>();
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
    }

    private void CheckWidthWall()
    {
        float lookDir = GameManager.Instance.PlayerInstance.playerMovement.playerLookDir;
        if (transform.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider)){}

        Vector3 startPosUpper = new Vector2(transform.position.x, collider.bounds.max.y);
        Vector3 startPosMiddle = new Vector2(transform.position.x, transform.position.y);
        Vector3 startPosLower = new Vector2(transform.position.x, collider.bounds.min.y);
        List<RaycastHit2D> hits = new List<RaycastHit2D>
        {
            Physics2D.Raycast(startPosUpper, lookDir * Vector2.right, size.x / 2 * (3f / 4f), whatIsWall),
            Physics2D.Raycast(startPosMiddle, lookDir * Vector2.right, size.x / 2 * (3f / 4f), whatIsWall),
            Physics2D.Raycast(startPosLower, lookDir * Vector2.right, size.x / 2 * (3f / 4f), whatIsWall)
        };
        
        Debug.DrawRay(startPosUpper, lookDir * Vector2.right * (size.x / 2 * (3f / 4f)));
        Debug.DrawRay(startPosMiddle, lookDir * Vector2.right * (size.x / 2 * (3f / 4f)));
        Debug.DrawRay(startPosLower, lookDir * Vector2.right * (size.x / 2 * (3f / 4f)));

        foreach (RaycastHit2D hit in hits)
        {
            if (hit)
            {
                GameManager.Instance.PlayerInstance.playerMovement.moveSpeed = 0;
                IsWidthLimit = true;
                return;
            }
        }
        IsWidthLimit = false;
        GameManager.Instance.PlayerInstance.playerMovement.moveSpeed = GameManager.Instance.PlayerInstance.DefaultMoveSpeed;
    }

    private void CheckHeightWall()
    {
        if (transform.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider)) { }

        Vector3 startPosRight = new Vector2(collider.bounds.max.x - 0.1f, transform.position.y);
        Vector3 startPosMiddle = new Vector2(transform.position.x, transform.position.y);
        Vector3 startPosLeft = new Vector2(collider.bounds.min.x + 0.1f, transform.position.y);
        List<RaycastHit2D> hits = new List<RaycastHit2D>
        {
            Physics2D.Raycast(startPosRight, Vector2.up, size.y / 2 * (3f / 5f), whatIsWall),
            Physics2D.Raycast(startPosMiddle, Vector2.up, size.y / 2 * (3f / 5f), whatIsWall),
            Physics2D.Raycast(startPosLeft, Vector2.up, size.y / 2 * (3f / 5f), whatIsWall)
        };

        Debug.DrawRay(startPosRight, Vector2.up * (size.y / 2 * (3f / 4f)));
        Debug.DrawRay(startPosMiddle, Vector2.up * (size.y / 2 * (3f / 4f)));
        Debug.DrawRay(startPosLeft, Vector2.up * (size.y / 2 * (3f / 4f)));
        
        foreach (RaycastHit2D hit in hits)
        {
            if (hit)
            {
                GameManager.Instance.PlayerInstance.alphabet.pickUpPos.y -= 5 * Time.deltaTime;
                return;
            }
        }
        GameManager.Instance.PlayerInstance.alphabet.pickUpPos = Vector3.Lerp(GameManager.Instance.PlayerInstance.alphabet.pickUpPos, GameManager.Instance.PlayerInstance.DefaultPickUpPos, Time.deltaTime * 3);
    }
}
