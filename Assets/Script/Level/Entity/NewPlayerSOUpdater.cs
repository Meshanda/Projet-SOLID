using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerSOUpdater : MonoBehaviour
{
    public List<PlayerData> PlayerDataToUpdate;

    public void OnNewPlayerAdded()
    {
        foreach(var PlayerData in PlayerDataToUpdate)
        {
            PlayerData.AddNew();
        }
    }
}
