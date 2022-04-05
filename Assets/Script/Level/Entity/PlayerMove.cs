using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : OrdonedMonoBehaviour
{
    public PlayerPositions PlayerPositions;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public PlayerIndexManager PlayerIndexManager;
    public PlayerHealth PlayerHealth;
    public PlayerClasses PlayerClasses;
    public PlayerDirections PlayerDirections;
    public Entity Entity;
    public TileEvent AttackOnTile;

    public GameEvent OnWait;

    public override void DoAwake()
    {

    }
    public override void DoUpdate()
    {
    }

    public void MoveInDirection(Vector2Int Direction)
    {
        if (!(Direction.magnitude == 1 && (Direction.x == 0 || Direction.y == 0))) return;
        if (!PlayerIndexManager) return;

        Vector2Int Position = PlayerPositions.GetPosition(PlayerIndexManager.Index);
        Vector2Int NewPosition = Position + Direction;

        if (PlayerDirections)
        {
            PlayerDirections.Directions[PlayerIndexManager.Index] = Direction;
        }

        Vector2Int AttackPos = MoveFromTo(Position, NewPosition) ? NewPosition : Position;

        MoveAttack(PlayerIndexManager.Index, AttackPos, Direction);
    }
    public void MoveTo(Vector2Int NewPosition)
    {
        if (!PlayerIndexManager) return;

        Vector2Int Position = PlayerPositions.GetPosition(PlayerIndexManager.Index);

        MoveFromTo(Position, NewPosition);
    }
    private bool MoveFromTo(Vector2Int Position, Vector2Int NewPosition)
    {
        if (!Tiles.Exists(NewPosition)) return false;
        if (TileEntities.TilePlayer(NewPosition) != -1) return false;

        LeaveTile(Position);
        JoinTile(NewPosition);
        PlayerPositions.SetPosition(PlayerIndexManager.Index, NewPosition);
        return true;
    }
    private void LeaveTile(Vector2Int Position)
    {
        if (TileEntities.GetEntity(Position) == Entity) { TileEntities.SetEntity(Position, null); }
    }
    private void JoinTile(Vector2Int Position)
    {
        TileEntities.SetEntity(Position, Entity);
    }

    private void MoveAttack(int Index, Vector2Int Position, Vector2Int Direction)
    {
        List<Vector2Int> MoveAttackPos = PlayerClasses.PlayerClassesList[Index].GetMoveAttackPos(Position, Direction);

        Vector2Int AttackPos;
        int TilePlayer;
        for (int i = 0; i < MoveAttackPos.Count; i++)
        {
            AttackPos = MoveAttackPos[i];
            if (Tiles.Exists(AttackPos))
            {
                TilePlayer = TileEntities.TilePlayer(AttackPos);
                if (TilePlayer != -1)
                {
                    Debug.Log(Index + " attacked " + TilePlayer + " from " + Position + " to " + AttackPos);
                    PlayerHealth.DecreaseHealth(TilePlayer);
                }
                if (!AttackOnTile) { return; }
                AttackOnTile.Raise(AttackPos);
            }
        }
    }
}
