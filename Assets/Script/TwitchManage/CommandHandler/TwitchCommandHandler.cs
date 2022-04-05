using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TwitchCommandHandler : ScriptableObject
{
    public List<string> twitchCommandName;
    [SerializeField] private bool needParams;
    public bool NeedParamas
    {
        get => needParams;
    }
    
    [SerializeField]protected PlayerCommand playerCommandExecuted;

    public abstract void HandleCommand(MessageData data);

    public bool Find(string command)
    {
        return twitchCommandName.Contains(command);
    }
}

public struct MessageData
{
    public string Author;
    public string Message;
}
