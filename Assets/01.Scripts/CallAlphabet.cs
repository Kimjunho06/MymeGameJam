using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAlphabet : MonoBehaviour
{
    public AlphabetType type;
    private PlayerController player;

    public ParticleSystem particle;

    private bool isUsed = false;

    private void Start()
    {
        player = GameManager.Instance.PlayerInstance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isUsed) return;

            particle.gameObject.SetActive(false);
            isUsed = true;
            if (type == AlphabetType.M)
            {
                GameObject.Find("M").transform.position = player.transform.position + (Vector3.up * 2f);
            }
            if (type == AlphabetType.O)
            {
                GameObject.Find("O").transform.position = player.transform.position + (Vector3.up * 2f);

            }
            if (type == AlphabetType.V)
            {
                GameObject.Find("V").transform.position = player.transform.position + (Vector3.up * 2f);

            }
            if (type == AlphabetType.E)
            {
                GameObject.Find("E").transform.position = player.transform.position + (Vector3.up * 2f);

            }
        }
    }
}
