using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerNames")]
public class PlayerNames : PlayerData
{
    public List<string> Names = new List<string>();

    public override void Init()
    {
        Names = new List<string>();
    }

    public void SetSize(int Size)
    {
        Names = new List<string>(Size);
    }

    public override void Remove(int Index)
    {
        Debug.Log(Names [Index] + " died");
        Names.RemoveAt(Index);
    }

    public override void AddNew()
    {
        Names.Add("");
    }

    public void AddNew(string Name)
    {
        Names.Add(Name);
    }

    public int GetPlayerIndex(string Name)
    {
        if (Contains(Name))
        {
            return Names.IndexOf(Name);
        }
        return -1;
    }

    public bool Contains(string name)
    {
        return Names.Contains(name);
    }

    public void ClearList()
    {
        Names.Clear();
    }

    public int GetPlayerCount()
    {
        return Names.Count;
    }
}

