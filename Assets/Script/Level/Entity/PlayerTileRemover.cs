using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileRemover : MonoBehaviour
{
    public TileEntities TileEntities;
    public PlayerIndexManager PlayerIndexManager;
    public PlayerPositions PlayerPositions;

    void OnDisable()
    {
        if(!PlayerIndexManager) { return; }
        if(!TileEntities) { return; }
        if(!PlayerPositions) { return; }

        TileEntities.SetEntity(PlayerPositions.GetPosition(PlayerIndexManager.Index), null);
    }
}
