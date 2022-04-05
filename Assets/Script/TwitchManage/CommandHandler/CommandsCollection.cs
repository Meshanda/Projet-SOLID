using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Command/Commands Collection")]
[Serializable]
public class CommandsCollection : ScriptableObject
{
    public List<TwitchCommandHandler> _availableCommands = new List<TwitchCommandHandler>();
    
    public void ExecuteCommands(string command, MessageData data)
    {
        //remove "!"
        command = command.Substring(1);
        bool multiAction;
        if (AvailableCommand(command,out multiAction))
        {
            TwitchCommandHandler commandExecuted = SearchCommand(command);
            if (!multiAction)
            {
                //invalid the command need or not parameters
                if(commandExecuted.NeedParamas == data.Message.Length > 0)
                    commandExecuted.HandleCommand(data);
            }
            else
            {
                //invalid the command if there are parameters
                if(data.Message.Length == 0)
                {
                    foreach (var letter in command)
                    {
                        commandExecuted = SearchCommand(letter.ToString());
                        commandExecuted.HandleCommand(data);
                    }
                }
            }
        }
    }

    private bool AvailableCommand(string commandName, out bool multiAction)
    {
        multiAction = false;
        if (SearchCommand(commandName))
            return true;

        if (commandName.Length > 3)
            return false;

        foreach (var letter in commandName)
        {
            if (!SearchCommand(letter.ToString()))
                return false;
        }

        multiAction = true;
        return true;
    }
    

    private TwitchCommandHandler SearchCommand(string commandName)
    {
        foreach (var command in _availableCommands)
        {
            if (command.Find(commandName))
                return command;
        }
        return null;
    }
}
