using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SaveData
{
    public List<string> ListPlayerClasses;
    public List<Vector2Int> ListPlayerDirections;

    public int MaxHealth;
    public List<int> ListPlayerHealth;

    public List<string> ListPlayerNames;
    public List<Vector2Int> ListPlayerPositions;

    public List<Vector2Int> ListTilePositions;
}

[System.Serializable]
public struct PlayerClassStruct
{
    public List<Vector2Int> MoveAttackPosition;
    public List<Vector2Int> IdleAttackPosition;
}