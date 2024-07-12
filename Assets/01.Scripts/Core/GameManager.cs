using System.Collections;
using System.Collections.Generic;
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
}
