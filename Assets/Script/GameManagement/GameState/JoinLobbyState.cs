using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "GameManagement/GameState/JoinLobbyState")]
public class JoinLobbyState : GameState
{
    [SerializeField] private PlayerNames playerNames;
    [SerializeField] private PlayerClasses playerClasses;
    
    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
        playerNames.ClearList();
        playerClasses.PlayerClassesList.Clear();
        TwitchChatConnected.Instance.WriteMessage("Time to start PogChamp : to join the game tap !join <class> in the chat. Archer = 0, Mage = 1, Warrior = 2");
    }
}
