using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameCommand/PlayerCommand/JoinGame")]
public class JoinPlayerCommand : PlayerCommand
{
    [SerializeField] private PlayerNames playerList;
    [SerializeField] private GameStateEvent playerJoinedEvent;
    [SerializeField] private FloatVariable playerMax;

    [SerializeField] private PlayerClasses PlayerClasses;
    public PlayerClass PlayerClass;
    
    public override void Execute(string playerName)
    {
        if(gameStateName.Value == StatesName.JoinLobby)
        {
            if(playerList.Names.Count < playerMax.Value)
            {
                if (!playerList.Contains(playerName))
                {
                    playerList.AddNew(playerName);
                    PlayerClasses.PlayerClassesList.Add(PlayerClass);
                    playerJoinedEvent.Raise();
                }
            }
        }
    }
}
