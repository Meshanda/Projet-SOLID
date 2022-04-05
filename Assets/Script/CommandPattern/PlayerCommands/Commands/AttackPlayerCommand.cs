using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameCommand/PlayerCommand/Attack")]
public class AttackPlayerCommand : PlayerCommand
{
    public override void Execute(string playerName)
    {
        TwitchChatConnected.Instance.WriteMessage($"{playerName} attack");
        
    }
}
