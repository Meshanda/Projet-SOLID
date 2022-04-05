using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerData : LevelData
{
    public abstract void AddNew();
    public abstract void Remove(int Index);
}
