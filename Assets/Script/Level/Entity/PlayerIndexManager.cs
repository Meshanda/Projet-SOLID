using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndexManager : OrdonedMonoBehaviour
{
    public int Index;
    public PlayerGO PlayerGo;

    public override void DoAwake()
    {
        if (!PlayerGo) { return; }

        Index = PlayerGo.GetPlayerCount();
    }
    
    public override void DoUpdate()
    {
        
    }
    public void OnPlayerDeath(int DeadPlayerIndex)
    {
        if (DeadPlayerIndex < Index)
        {
            Index--;
        }
    }
}
