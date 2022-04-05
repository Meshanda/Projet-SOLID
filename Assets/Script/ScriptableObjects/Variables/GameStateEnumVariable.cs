using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Variables/GameStateName", fileName = "New StateName")]
public class GameStateEnumVariable : ScriptableObject
{
    public StatesName Value;
}
