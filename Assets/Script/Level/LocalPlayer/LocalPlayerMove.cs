using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerMove : MonoBehaviour
{
    private string playerName;

    public RoundCommand _roundCommand;

    public List<KeyCode> _keyPressed;
    public List<PlayerCommand> _commands;

    private void Start()
    {
        playerName = name;
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Math.Min(_keyPressed.Count, _commands.Count); i++)
        {
            if(Input.GetKeyDown(_keyPressed[i]))
            {
                _roundCommand.Execute(playerName, _commands[i]);
            }
        }
    }
}
