using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerHealth")]
public class PlayerHealth : PlayerData
{
    public int MaxHealth = 2;
    public List<int> PlayerHealthList = new List<int>();
    public PlayerEvent PlayerDeath;

    public override void Init()
    {
        PlayerHealthList = new List<int>();
    }

    public void DecreaseHealth(int Index)
    {
        PlayerHealthList[Index]--;
        if (PlayerHealthList[Index] <= 0)
        {
            PlayerDeath.Raise(Index);
        }
    }

    public override void Remove(int Index)
    {
        PlayerHealthList.RemoveAt(Index);
    }

    public void SetSize(int Size)
    {
        PlayerHealthList = new List<int>(Size);
    }

    public override void AddNew()
    {
        PlayerHealthList.Add(MaxHealth);
    }

    public void ClearList()
    {
        PlayerHealthList.Clear();
    }
}
