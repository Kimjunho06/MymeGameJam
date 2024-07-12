using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlphabetAbility : MonoBehaviour
{
    private Dictionary<AlphabetType, Ability> _typeDictionary = new Dictionary<AlphabetType, Ability>();

    private void Awake()
    {
        foreach (AlphabetType stateEnum in Enum.GetValues(typeof(AlphabetType)))
        {
            string typeName = stateEnum.ToString();
            Type t = Type.GetType($"Alphabet{typeName}Ability");
            Ability newState = Activator.CreateInstance(t) as Ability;
            AddState(stateEnum, newState);
        }
    }

    private void Start()
    {
        foreach (var state in _typeDictionary)
        {
            state.Value.Init();
        }
    }

    public void InvokeAbility(AlphabetSO alphabetSO)
    {
        if (!GameManager.Instance.PlayerInstance)
        {
            Debug.LogError("Player Is Null");
            return;
        }
        _typeDictionary[alphabetSO.alphabetType].PlayAbility(GameManager.Instance.PlayerInstance);
    }

    public void ResetAbility(AlphabetSO alphabetSO)
    {
        if (!GameManager.Instance.PlayerInstance)
        {
            Debug.LogError("Player Is Null");
            return;
        }
        _typeDictionary[alphabetSO.alphabetType].ResetAbility(GameManager.Instance.PlayerInstance);
    }

    private void AddState(AlphabetType type, Ability ability)
    {
        _typeDictionary.Add(type, ability);
    }
}
