using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/MapConfiguration")]
public class MapConfiguration : ScriptableObject
{
    public List<Vector2Int> TilePositions;
}