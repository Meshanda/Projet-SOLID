using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerClass")]
public class PlayerClass : ScriptableObject
{
    public List<Vector2Int> MoveAttackLocalPos;
    public List<Vector2Int> AttackLocalPos;

    public List<Vector2Int> GetMoveAttackPos(Vector2Int Position, Vector2Int Direction)
    {
        List<Vector2Int> MoveAttackGlobalPos = new List<Vector2Int>();
        for (int i = 0; i < MoveAttackLocalPos.Count; i++)
        {
            MoveAttackGlobalPos.Add(Position + RotateVector(MoveAttackLocalPos[i], Direction));
        }
        return MoveAttackGlobalPos;
    }

    public List<Vector2Int> GetSpecialAttackPos(Vector2Int Position, Vector2Int Direction)
    {
        List<Vector2Int> AttackGlobalPos = new List<Vector2Int>();
        for (int i = 0; i < AttackLocalPos.Count; i++)
        {
            AttackGlobalPos.Add(Position + RotateVector(AttackLocalPos[i], Direction));
        }
        return AttackGlobalPos;
    }

    private Vector2Int RotateVector(Vector2Int Vector, Vector2Int Direction)
    {
        return new Vector2Int(Direction.x * Vector.x - Direction.y * Vector.y, Direction.y * Vector.x + Direction.x * Vector.y);
    }

}
