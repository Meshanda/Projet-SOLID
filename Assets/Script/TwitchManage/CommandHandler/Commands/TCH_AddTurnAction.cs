using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twitch/Command/AddTurnAction")]
public class TCH_AddTurnAction : TwitchCommandHandler
{
    public RoundCommand RoundCommand;
    
    public override void HandleCommand(MessageData data)
    {
        RoundCommand.Execute(data.Author, playerCommandExecuted);
    }
}
