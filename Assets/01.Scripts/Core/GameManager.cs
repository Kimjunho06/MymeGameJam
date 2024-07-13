using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private PlayerController _player;
    public PlayerController PlayerInstance
    {
        get
        {
            if (!_player)
            {
                if (!HasPlayer)
                {
                    Debug.LogError("Player instance doesn't exist.");
                }
            }

            return _player;
        }
    }
    public bool HasPlayer
    {
        get
        {
            return _player = FindObjectOfType<PlayerController>();
        }

        private set
        {

        }
    }

    public int deathCount = 0;
    public float playtime = 0;
    public float progress = 0;

    public bool IsGameStart = false;

    public Sprite onSwitch;
    public Sprite offSwitch;

    public SpriteRenderer shineObj;
    private float shineA;

    private bool isSeeManhwa;
    
    private void Start()
    {
        SoundManager.Instance.Play(SoundManager.Instance._bgm, SoundEnum.BGM);
        shineA = shineObj.color.a;

        Color color = shineObj.color;
        color.a = 0;

        shineObj.color = color;
        isSeeManhwa = false;
    }

    private void Update()
    {
        if (MCSceneManager.Instance.CurrentSceneIndex == 5)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.Quit();
            }
        }

        if (IsGameStart)
        {
            playtime += Time.deltaTime;

        }

        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.ClickSound();
         
            if (UIManager.Instance.optionPanel.activeSelf)
            {
                return;
            }
            
            if (!IsGameStart && MCSceneManager.Instance.CurrentSceneIndex != 1 && MCSceneManager.Instance.CurrentSceneIndex != 5)
            {
                if (isSeeManhwa) return;

                isSeeManhwa = true;
                MCSceneManager.Instance.ChangeScene(1);
            }
        }
    }

    public string RecordPlayTime()
    {
        int hour = (int)playtime / 3600;
        int minute = (int)playtime / 60;
        int second = (int)playtime % 60;

        string playTimeString = $"{hour} : {minute} : {second}";
        return playTimeString;
    }

    public void ShineOn()
    {
        StartCoroutine(ShineOnCoroutine());
    }

    private IEnumerator ShineOnCoroutine()
    {
        while (shineA >= shineObj.color.a)
        {
            Color color = shineObj.color;
            color.a += Time.deltaTime * 0.5f;

            shineObj.color = color;
            yield return null;
        }

    }
}
