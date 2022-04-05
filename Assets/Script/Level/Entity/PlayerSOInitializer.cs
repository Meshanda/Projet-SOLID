using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSOInitializer : OrdonedMonoBehaviour
{
    public List<PlayerData> _playerDatas;
    public PlayerNames PlayerNames;

    public override void DoAwake()
    {
        foreach (var PlayerData in _playerDatas)
        {
            PlayerData.Init();
        }
    }
    public override void DoUpdate()
    {

    }
}
