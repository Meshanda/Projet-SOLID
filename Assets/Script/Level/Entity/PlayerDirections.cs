using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerDirections")]
public class PlayerDirections : PlayerData
{
    [SerializeField]
    public List<Vector2Int> Directions = new List<Vector2Int>();

    public override void Init()
    {
        Directions = new List<Vector2Int>();
    }

    public override void AddNew()
    {
        Directions.Add(new Vector2Int(0, 1));
    }

    public override void Remove(int Index)
    {
        Directions.RemoveAt(Index);
    }
}