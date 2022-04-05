using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfigurator : OrdonedMonoBehaviour
{
    public MapConfiguration MapConfiguration;
    public GameEvent MapConfigurated;
    public Vector2IntListVariable PlayerSpawnPositions;
    public FloatVariable MinTileCoverage;
    public FloatVariable MaxTileCreationAttemptFactor;
    public IntVariable StartLandPer100Tiles;
    public FloatVariable MapLength;
    public FloatVariable MapHeight;

    public override void DoAwake()
    {
        CreateMap();
    }

    public override void DoUpdate()
    {

    }

    private void CreateMap()
    {
        int Length = (int) MapLength.Value;
        int Height = (int) MapHeight.Value;
        int Size = Length * Height;
        int MinTileCount = (int)(MinTileCoverage.Value * Size);
        int MaxTileCreationAttempts = (int)(MaxTileCreationAttemptFactor.Value * Size);
        int StartLandsCount = StartLandPer100Tiles.Value * Size / 100;
        List<Vector2Int> StartLands = new List<Vector2Int>();
        int[,] Map = new int[Length, Height];
        MapInit(ref Map, Length, Height);
        CalcStartLands(ref StartLands, StartLandsCount, MaxTileCreationAttempts, Length, Height);
        AddStartLands(ref Map, StartLands);
        AddTiles(ref Map, MaxTileCreationAttempts, MinTileCount, Length, Height);
        UpdateMapConfiguration(Map, Length, Height);
        UpdatePlayerSpawns();
    }

    void MapInit(ref int[,] Map, int Length, int Height)
    {
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Map[i, j] = -1;
            }
        }
    }

    void CalcStartLands(ref List<Vector2Int> StartLands, int StartLandsCount, int MaxTileCreationAttempts, int Length, int Height)
    {
        Vector2Int StartLandPos;
        int j = 0;
        for (int i = 0; i < MaxTileCreationAttempts; i++)
        {
            StartLandPos = new Vector2Int(Random.Range(0, Length), Random.Range(0, Height));
            bool IsValid = true;
            for (int k = j; k < StartLands.Count; k++)
            {
                if ((StartLandPos - StartLands[k]).magnitude <= 1)
                {
                    IsValid = false;
                    break;
                }
            }
            if (IsValid)
            {
                StartLands.Add(StartLandPos);
                j++;
            }
            if (j >= StartLandsCount)
            {
                break;
            }
        }
    }

    void AddStartLands(ref int[,] Map, List<Vector2Int> StartLands)
    {
        int StartLandsCount = StartLands.Count;
        for (int i = 0; i < StartLandsCount; i++)
        {
            Map[StartLands[i].x, StartLands[i].y] = i;
        }
    }

    void AddTiles(ref int[,] Map, int MaxTileCreationAttempts, int MinTileCount, int Length, int Height)
    {
        Vector2Int NewTile;
        bool TestCluster = false;
        int TileCount = 0;

        for (int i = 0; i < MaxTileCreationAttempts; i++)
        {
            NewTile = new Vector2Int(Random.Range(0, Length), Random.Range(0, Height));
            if (Map[NewTile.x, NewTile.y] == -1)
            {
                if (NewTile.x > 0)
                {
                    int LeftMapValue = Map[NewTile.x - 1, NewTile.y];
                    if (LeftMapValue != -1)
                    {
                        Map[NewTile.x, NewTile.y] = LeftMapValue;
                        TileCount++;
                    }
                }
                if (NewTile.x < Length - 1)
                {
                    int RightMapValue = Map[NewTile.x + 1, NewTile.y];
                    CheckValue(ref Map, RightMapValue, NewTile, ref TileCount, Length, Height);
                }
                if (NewTile.y > 0)
                {
                    int DownMapValue = Map[NewTile.x, NewTile.y - 1];
                    CheckValue(ref Map, DownMapValue, NewTile, ref TileCount, Length, Height);
                }
                if (NewTile.y < Height - 1)
                {
                    int UpMapValue = Map[NewTile.x, NewTile.y + 1];
                    CheckValue(ref Map, UpMapValue, NewTile, ref TileCount, Length, Height);
                }
            }

            if (!TestCluster) { TestCluster = TestClusters(Map, Length, Height); }
            if (TestCluster && TileCount >= MinTileCount) { break; }
        }
    }

    void CheckValue(ref int[,] Map, int MapValue, Vector2Int NewTile, ref int TileCount, int Length, int Height)
    {
        if (MapValue != -1)
        {
            if (Map[NewTile.x, NewTile.y] == -1)
            {
                Map[NewTile.x, NewTile.y] = MapValue;
                TileCount++;
            }
            if (MapValue != Map[NewTile.x, NewTile.y])
            {
                MergeClusters(new Vector2Int(Map[NewTile.x, NewTile.y], MapValue), ref Map, Length, Height);
            }
        }
    }

    void MergeClusters(Vector2Int ClustersToMerge, ref int[,] Map, int Length, int Height)
    {
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (Map[i,j] == ClustersToMerge.y) { Map[i,j] = ClustersToMerge.x; }
            }
        }
    }

    bool TestClusters(int[,] Map, int Length, int Height)
    {
        int Cluster = -1;
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (Map[i,j] != -1)
                {
                    if (Cluster == -1)
                    {
                        Cluster = Map[i,j];
                    }
                    else if (Cluster != Map[i,j])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    void UpdateMapConfiguration(int[,] Map, int Length, int Height)
    {
        if (!MapConfiguration) return;
        MapConfiguration.TilePositions = new List<Vector2Int>();
        int HalfLength = Length / 2;
        int HalfHeight = Height / 2;
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (Map[i, j] != -1)
                {
                    MapConfiguration.TilePositions.Add(new Vector2Int(i - HalfLength, j - HalfHeight));
                }
            }
        }
        MapConfigurated.Raise();
    }

    void UpdatePlayerSpawns()
    {
        if (!PlayerSpawnPositions) return;
        if (!MapConfiguration) return;
        PlayerSpawnPositions.Value = ShuffleList(MapConfiguration.TilePositions);
    }

    List<Vector2Int> ShuffleList(List<Vector2Int> List)
    {
        int j;
        for (int i = List.Count - 1; i > 1; i--)
        {
            j = Random.Range(0, i);
            Vector2Int k = List[j];
            List[j] = List[i];
            List[i] = k;
        }
        return List;
    }
}
