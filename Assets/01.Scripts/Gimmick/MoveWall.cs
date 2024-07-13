using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        CameraManager.Instance.ShakeCam(0.6f, 0.2f, 1f);
    }

    private void Update()
    {
        speed += Time.deltaTime * 0.0001f;

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
