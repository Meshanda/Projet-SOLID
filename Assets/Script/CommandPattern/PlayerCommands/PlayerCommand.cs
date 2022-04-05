using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCommand : ScriptableObject
{
    public abstract void Execute(string playerName);
    
    
    [SerializeField] protected GameStateEnumVariable gameStateName;
}
