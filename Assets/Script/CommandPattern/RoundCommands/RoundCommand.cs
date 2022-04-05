using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoundCommand : ScriptableObject
{
    [SerializeField]protected GameStateEnumVariable gameStateName;
    
    public abstract void Execute(string playerName, PlayerCommand playerCommand);
}
