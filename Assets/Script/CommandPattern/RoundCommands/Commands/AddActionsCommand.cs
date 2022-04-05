using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameCommand/RoundCommand/AddAction")]
public class AddActionsCommand : RoundCommand
{
    [SerializeField] private PlayerNames _playerNames;
    
    public override void Execute(string playerName, PlayerCommand playerCommand)
    {
        if (gameStateName.Value == StatesName.WaitTurnActions)
        {
            if(_playerNames.Contains(playerName))
            {
                RoundCommandHistory.Instance.AddCommand(playerName, playerCommand);
            }
        }
    }
}
