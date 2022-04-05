using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerPositions")]
public class PlayerPositions : PlayerData
{
    public GameEvent PlayerPositionChanged;
    [SerializeField]
    private List<Vector2Int> positions = new List<Vector2Int>();

    public override void Init()
    {
        positions = new List<Vector2Int>();
    }

    public override void AddNew()
    {
        positions.Add(Vector2Int.zero);
    }

    public override void Remove(int Index)
    {
        positions.RemoveAt(Index);
    }

    public void SetPosition(int PlayerIndex, Vector2Int Position)
    {
        if (!PlayerPositionChanged) { return; }
        positions[PlayerIndex] = Position;
        PlayerPositionChanged.Raise();
    }

    public void AddPosition(int PlayerIndex, Vector2Int Position)
    {
        if (!PlayerPositionChanged) { return; }
        positions[PlayerIndex] += Position;
        PlayerPositionChanged.Raise();
    }

    public Vector2Int GetPosition(int PlayerIndex)
    {
        if (positions.Count <= PlayerIndex) { return Vector2Int.zero; }
        return positions[PlayerIndex];
    }

    public int GetPlayerCount()
    {
        return positions.Count;
    }

    public void SetPositionList(List<Vector2Int> newPositionList)
    {
        positions = newPositionList;
    }

    public List<Vector2Int> GetPositionList()
    {
        return positions;
    }
}