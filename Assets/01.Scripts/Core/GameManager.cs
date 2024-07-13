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

    private void Start()
    {
        SoundManager.Instance.Play(SoundManager.Instance._bgm, SoundEnum.BGM);
    }

    private void Update()
    {
        if (IsGameStart)
        {
            playtime += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.ClickSound();
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

    

}
