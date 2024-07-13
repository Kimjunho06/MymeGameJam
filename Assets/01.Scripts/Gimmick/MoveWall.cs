using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        speed += Time.deltaTime * 0.005f;

        transform.position += Vector3.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MCSceneManager.Instance.ResetScene();
        }
    }
}
