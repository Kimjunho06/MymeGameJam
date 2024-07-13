using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActionObject : SwitchActionObject
{
    public float moveSpeed = 3f;

    public Vector3 movePos;
    public Vector3 defaultPos;

    private void Start()
    {
        defaultPos = transform.position;
        movePos += transform.position;
    }

    protected override void InvokeAction()
    {
        transform.position = Vector3.Lerp(transform.position, movePos, Time.deltaTime * moveSpeed);
    }

    protected override void ResetAction()
    {
        transform.position = Vector3.Lerp(transform.position, defaultPos, Time.deltaTime * moveSpeed);
    }
}
