using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public List<PlayerData> PlayerDataToUpdate;
    public PlayerGO PlayerGO;

    public void OnPlayerDeath(int Index)
    {
        if (!PlayerGO) { return; }
        Destroy(PlayerGO.GameObjects[Index]);
        foreach (var PlayerData in PlayerDataToUpdate)
        {
            PlayerData.Remove(Index);
        }
        print(Index + " ded");
    }
}
