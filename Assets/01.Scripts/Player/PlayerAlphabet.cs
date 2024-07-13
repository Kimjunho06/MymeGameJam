using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlphabet : MonoBehaviour
{
    [Header("Setting Parameters")]
    public float pickCheckRadius;
    public Vector3 pickUpPos;

    public float releasePosMultiplier = 0.3f;

    public Vector2 throwVector = Vector2.one;
    public float throwpower = 2f;
    public float smallLetterThrowPower = 3f;

    [Header("Develop Parameters")]
    public bool IsPickUp;
    public LayerMask whatIsAlphabet;

    // SO
    public Alphabet pickUpAlphabet;
    private RigidbodyConstraints2D pickUpAlphabetConstraints;
    public int pickUpAlphabetRotation;

    public bool IsReleaseFront = true; // 앞에 두기 위해 살짝 던지는 기능 킬 것인가?.

    private void Start()
    {
        
    }

    private void Update()
    {
        if (IsPickUp)
        {
            pickUpAlphabet.transform.position = transform.position + pickUpPos;
        }
    }

    public void PickUp()
    {
        if (!IsPickUp)
        {
            if (IsPickAble())
            {
                HoldAlphabet();
            }
        }
        else
        {
            ReleaseAlphabet();
        }

    }

    private void HoldAlphabet()
    {
        if (!pickUpAlphabet.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider))
        {
            Debug.LogError("Pickup Alphabet Is not Contain Collider");
            return;
        }
        if (!pickUpAlphabet.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            Debug.LogError("Pickup Alphabet Is not Contain Rigidbody");
            return;
        }

        IsPickUp = true;

        pickUpAlphabetRotation = (int)CalculatePickRotationValue();
        pickUpAlphabet.transform.eulerAngles = new Vector3(0, 0, pickUpAlphabetRotation);

        pickUpAlphabetConstraints = rigidbody.constraints;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        //collider.enabled = false;
        rigidbody.gravityScale = 0;
    }

    private void ReleaseAlphabet()
    {
        if (!pickUpAlphabet.TryGetComponent<PolygonCollider2D>(out PolygonCollider2D collider))
        {
            Debug.LogError("Pickup Alphabet Is not Contain Collider");
            return;
        }
        if (!pickUpAlphabet.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            Debug.LogError("Pickup Alphabet Is not Contain Rigidbody");
            return;
        }

        float lookDir = GameManager.Instance.PlayerInstance.playerMovement.playerLookDir;
        if (GameManager.Instance.PlayerInstance.playerMovement.IsMoved)
        {
            GameManager.Instance.PlayerInstance.playerMovement.animator.SetTrigger("IsThrow");
            //Throw
            Vector3 throwVec = throwVector;
            if (pickUpAlphabet.AlphabetSO.isSamllLetter)
                throwVec *= smallLetterThrowPower;
            else
                throwVec *= throwpower;

            throwVec.x *= lookDir;
            rigidbody.velocity = throwVec;

        }
        else
        {
            if (IsReleaseFront)
            {
                GameManager.Instance.PlayerInstance.playerMovement.animator.SetTrigger("IsRelease");

                Vector3 releasePos = Vector3.zero;
                releasePos.x = lookDir * releasePosMultiplier;

                rigidbody.velocity = releasePos;
            }
        }


        IsPickUp = false;
        pickUpAlphabet = null;

        rigidbody.constraints = pickUpAlphabetConstraints;
        pickUpAlphabetConstraints = RigidbodyConstraints2D.None;


        collider.enabled = true;
        rigidbody.gravityScale = 1;
    }

    public void RotateAlphabet()
    {
        pickUpAlphabetRotation += 90;

        pickUpAlphabet.transform.eulerAngles = new Vector3(0, 0, -pickUpAlphabetRotation);
    }

    private float CalculatePickRotationValue()
    {
        float zAngle = pickUpAlphabet.transform.eulerAngles.z;
        zAngle %= 360;

        zAngle /= 45;

        if (zAngle < 1 || zAngle >= 7)
            zAngle = 0;
        else if (zAngle < 3 && zAngle >= 1) 
            zAngle = 1;
        else if (zAngle < 5 && zAngle >= 3) 
            zAngle = 2;
        else if (zAngle < 7 && zAngle >= 5)
            zAngle = 3;

        return (zAngle * 90f);
    }

    private bool IsPickAble()
    {
        // Overlap2D
        Collider2D alphabetObj = Physics2D.OverlapCircle(transform.position, pickCheckRadius, whatIsAlphabet);
        if (alphabetObj == null)
            return false;

        if (alphabetObj.TryGetComponent<Alphabet>(out Alphabet alphabet))
        {
            pickUpAlphabet = alphabet;
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //
        //Gizmos.DrawWireSphere(transform.position, pickCheckRadius);
    }
}
