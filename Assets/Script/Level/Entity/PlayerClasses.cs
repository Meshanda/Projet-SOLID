using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerClasses")]
public class PlayerClasses : PlayerData
{
    public List<PlayerClass> AvailableClasses = new List<PlayerClass>();
    public List<PlayerClass> PlayerClassesList = new List<PlayerClass>();

    public override void Init()
    {
        PlayerClassesList = new List<PlayerClass>();
    }

    public void SetSize(int Size)
    {
        PlayerClassesList = new List<PlayerClass>(Size);
    }

    public override void AddNew()
    {
        PlayerClassesList.Add(AvailableClasses[0]);
    }

    public override void Remove(int Index)
    {
        PlayerClassesList.RemoveAt(Index);
    }

    public void AddNew(string ClassName)
    {
        PlayerClassesList.Add(AvailableClasses[ClassIndex(ClassName)]);
    }

    public void ClearList()
    {
        PlayerClassesList.Clear();
    }

    public void SetPlayerClass(int Index, string ClassName)
    {
        PlayerClassesList[Index] = AvailableClasses[ClassIndex(ClassName)];
    }

    public int ClassIndex(string ClassName)
    {
        for (int i = 0; i < AvailableClasses.Count; i++)
        {
            if (AvailableClasses[i].name == ClassName)
            {
                return i;
            }
        }
        return 0;
    }
}

