using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : OrdonedMonoBehaviour
{
    public GameObject TilePrefab;
    public MapConfiguration MapConfiguration;
    public TileEvent AddedNewTile;

    public override void DoAwake()
    {
        if (MapConfiguration)
        {
            for (int i = 0; i < MapConfiguration.TilePositions.Count; i++)
            {
                SpawnTile(MapConfiguration.TilePositions[i]);
            }
        }
    }
    public override void DoUpdate()
    {

    }

    public void SpawnTile(Vector2Int Position)
    {
        if (!TilePrefab) return;
        GameObject Tile = Instantiate(TilePrefab, new Vector3(Position.x, Position.y, 0), Quaternion.identity);
        AddedNewTile.Raise(Position);
    }
}
