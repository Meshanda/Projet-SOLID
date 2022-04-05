using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSOInitializer : OrdonedMonoBehaviour
{
    [SerializeField] private List<TileData> _tileDatas;

    public override void DoAwake()
    {
        foreach (var TileData in _tileDatas)
        {
            TileData.Init();
        }
    }
    public override void DoUpdate()
    {
        
    }
}
