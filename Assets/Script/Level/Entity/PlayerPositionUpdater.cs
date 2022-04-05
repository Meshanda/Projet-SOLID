using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionUpdater : MonoBehaviour
{
    public PlayerPositions PlayerPositions;
    public PlayerIndexManager PlayerIndexManager;

    public void OnPlayerPositionChanged()
    {
        if (!PlayerPositions) return;
        if (!PlayerIndexManager) return;
        Vector2Int PlayerPositionVector = PlayerPositions.GetPosition(PlayerIndexManager.Index);
        transform.position = new Vector3(PlayerPositionVector.x, PlayerPositionVector.y, 0);
    }
}