using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public PlayerIndexManager PlayerIndexManager;
    public PlayerClasses PlayerClasses;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public PlayerHealth PlayerHealth;
    public TileEvent AttackOnTile;

    private void SpecialAttack(Vector2Int Position, Vector2Int Direction)
    {
        if (!PlayerIndexManager) { return; }

        List<Vector2Int> SpecialAttackPos = PlayerClasses.PlayerClassesList[PlayerIndexManager.Index].GetSpecialAttackPos(Position, Direction);

        Vector2Int AttackPos;
        int TilePlayer;
        for (int i = 0; i < SpecialAttackPos.Count; i++)
        {
            AttackPos = SpecialAttackPos[i];
            if (Tiles.Exists(AttackPos))
            {
                TilePlayer = TileEntities.TilePlayer(AttackPos);
                if (TilePlayer != -1)
                {
                    Debug.Log(PlayerIndexManager.Index + " special attacked " + TilePlayer + " from " + Position + " to " + AttackPos);
                    PlayerHealth.DecreaseHealth(TilePlayer);
                }
                if (!AttackOnTile) { return; }
                AttackOnTile.Raise(AttackPos);
            }
        }
    }
}
