using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerGameObjects")]
public class PlayerGO : PlayerData
{
    public List<GameObject> GameObjects = new List<GameObject>();

    public override void Init()
    {
        GameObjects = new List<GameObject>();
    }

    public void SetSize(int Size)
    {
        GameObjects = new List<GameObject>(Size);
    }

    public void Set(int Index, GameObject GameObject)
    {
        Debug.Log(GameObjects.Count + "   " + Index);
        GameObjects[Index] = GameObject;
    }

    public override void AddNew()
    {

    }

    public override void Remove(int Index)
    {
        GameObjects.RemoveAt(Index);
    }

    public void AddNew(GameObject GameObject)
    {
        GameObjects.Add(GameObject);
    }

    public bool Contains(GameObject GameObject)
    {
        return GameObjects.Contains(GameObject);
    }

    public void ClearList()
    {
        GameObjects.Clear();
    }

    public int GetPlayerCount()
    {
        return GameObjects.Count;
    }
}

