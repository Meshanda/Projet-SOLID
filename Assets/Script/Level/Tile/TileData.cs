using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileData : LevelData
{
    public abstract void AddNew(Vector2Int Position);
}
