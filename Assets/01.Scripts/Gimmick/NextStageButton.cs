using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextStageButton : MonoBehaviour
{
    public LockObject[] lockObjs;

    private float _endDistance;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        lockObjs = GameObject.FindObjectsOfType<LockObject>();

        Vector2 trm = transform.position;
        Vector2 playerTrm = GameManager.Instance.PlayerInstance.transform.position;

        trm.y = 0;
        playerTrm.y = 0;

        _endDistance = Vector3.Distance(trm, playerTrm);
    }

    private void Update()
    {
        Vector2 trm = transform.position;
        Vector2 playerTrm = GameManager.Instance.PlayerInstance.transform.position;

        trm.y = 0;
        playerTrm.y = 0;

        float curDist = 0;
        curDist = Vector3.Distance(trm, playerTrm);

        GameManager.Instance.progress = 100 - (curDist / _endDistance) * 100f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (lockObjs.Length > 0)
        {
            foreach (var obj in lockObjs)
            {
                if (!obj.IsLock) return;
            }
        }

        if (collision.collider.CompareTag("Player"))
        {
            SoundManager.Instance.Play(_audioSource.clip);
            MCSceneManager.Instance.ChangeScene();
        }
    }
}
