using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIndexManager : OrdonedMonoBehaviour
{
    public int Index;
    public Tiles Tiles;

    public override void DoAwake()
    {
        if (!Tiles) { return; }
        Index = Tiles.TileList.Count;
    }
    public override void DoUpdate()
    {
        
    }
}