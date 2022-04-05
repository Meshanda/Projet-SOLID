using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorDirectionMove
{
    public static Vector2Int FetchDirection(DirectionMove directionMove)
    {
        switch (directionMove)
        {
          case  DirectionMove.Up:
              return Vector2Int.up;
          case  DirectionMove.Down:
              return Vector2Int.down;
          case  DirectionMove.Left:
              return Vector2Int.left;
          case  DirectionMove.Right:
              return Vector2Int.right;
          default: return Vector2Int.zero;
        }
    }
}

public enum DirectionMove
{
    Up,
    Down,
    Left,
    Right
}

