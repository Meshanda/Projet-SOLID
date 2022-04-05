using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/TileEntities")]
public class TileEntities : TileData
{
    private Dictionary<Vector2Int, Entity> _tileEntitiesList = new Dictionary<Vector2Int, Entity>();

    //////////////
    public List<Vector2Int> Pos = new List<Vector2Int>();
    public List<Entity> Ent = new List<Entity>();
    //////////////

    public override void Init()
    {
        _tileEntitiesList = new Dictionary<Vector2Int, Entity>();

        //////////////
        Pos = new List<Vector2Int>();
        Ent = new List<Entity>();
        //////////////
    }

    public override void AddNew(Vector2Int Position)
    {
        _tileEntitiesList.Add(Position, null);

        //////////////
        Pos.Add(Position);
        Ent.Add(null);
        //////////////
    }

    public int TilePlayer(Vector2Int Position)
    {
        if (!_tileEntitiesList.ContainsKey(Position)) return -1;
        Entity Entity = _tileEntitiesList[Position];
        if (!(Entity is Player)) { return -1; }
        Player Player = (Player)Entity;
        PlayerIndexManager PlayerIndexManager = Player.gameObject.GetComponent<PlayerIndexManager>();
        if (!PlayerIndexManager) { return -1; }
        return PlayerIndexManager.Index;
    }

    public Entity GetEntity(Vector2Int Position)
    {
        if (!_tileEntitiesList.ContainsKey(Position)) { return null; }
        return _tileEntitiesList[Position];
    }

    public void SetEntity(Vector2Int Position, Entity Entity)
    {
        _tileEntitiesList[Position] = Entity;

        //////////////
        for (int i = 0; i < Pos.Count; i++)
        {
            if (Pos[i] == Position)
            {
                Ent[i] = Entity;
            }
        }
        //////////////
    }
}
