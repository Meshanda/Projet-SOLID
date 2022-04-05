using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnCommandsHistory
{
    private Dictionary<string, PlayerCommand> _allCommand = new Dictionary<string, PlayerCommand>();

    public IEnumerator ExecuteCommands(float delayTime)
    {
        foreach (var command in _allCommand)
        {
            command.Value.Execute(command.Key);
            yield return new WaitForSeconds(delayTime);
        }

        RoundCommandHistory.Instance.endTurn = true;
    }

    public bool AddCommand(string playerPseudo, PlayerCommand playerCommand)
    {
        if (HaveAnAction(playerPseudo))
            return false;
        _allCommand.Add(playerPseudo, playerCommand);
        return true;
    }

    private bool HaveAnAction(string playerPseudo)
    {
        return _allCommand.ContainsKey(playerPseudo);
    }

    public int NumberOfActions()
    {
        return _allCommand.Count;
    }

    public void ClearCommands()
    {
        _allCommand.Clear();
    }
}
