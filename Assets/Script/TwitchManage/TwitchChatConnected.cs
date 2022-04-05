using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using UnityEngine;

public class TwitchChatConnected : MySingleton<TwitchChatConnected>
{
    [SerializeField] private CommandsCollection _commandsCollection;

    private TcpClient _twitchClient;
    
    private StreamReader _reader;
    private StreamWriter _writer;

    [SerializeField] private TwitchAcountCredentials twitchAcountCredentials;


    protected override bool DoDestroyOnLoad => true;
    

    private void Start()
    {
        Application.runInBackground = true;
    }

    private void Update()
    {
        if (_twitchClient != null && _twitchClient.Connected)
        {
            ReadChat();
        }
    }


    public void ConnectClient()
    {
        DisconnectClient();
        _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream());

        _writer.WriteLine($"PASS {twitchAcountCredentials.OauthPassword}");
        _writer.WriteLine($"NICK {twitchAcountCredentials.Username}");
        _writer.WriteLine($"JOIN #{twitchAcountCredentials.TwitchAcountName}");
        _writer.Flush();
    }

    public void DisconnectClient()
    {
        if (_twitchClient == null)
            return;
        
        if(_twitchClient.Connected)
        {
            _twitchClient.Close();
        }
    }
    
    public void ReadChat()
    {
        if (_twitchClient.Available > 0)
        {
            string chatMessage = _reader.ReadLine();
            Debug.Log(chatMessage);

            if (chatMessage.Contains("PING"))
            {
                _writer.WriteLine("PONG");
                _writer.Flush();
                return;
            }

            if (chatMessage.Contains("PRIVMSG"))
            {
                var splitPoint = chatMessage.IndexOf("!", 1, StringComparison.Ordinal);
                var author = chatMessage.Substring(0, splitPoint);
                author = author.Substring(1);

                splitPoint = chatMessage.IndexOf(":", 1, StringComparison.Ordinal);
                chatMessage = chatMessage.Substring(splitPoint + 1);

                if (chatMessage.StartsWith(CommandsPrefix.Prefix))
                {
                    int index = chatMessage.IndexOf(" ");
                    string command = index > -1 ? chatMessage.Substring(0, index) : chatMessage;
                    
                    _commandsCollection.ExecuteCommands(command, new MessageData
                    {
                        Author = author,
                        Message = chatMessage.Substring($"{CommandsPrefix.Prefix}{command}".Length - 1)
                    });
                }
            }
            
        }
    }


    public void WriteMessage(string Message)
    {
        if (_twitchClient.Connected)
        {
            _writer.WriteLine($"PRIVMSG #{twitchAcountCredentials.TwitchAcountName} :{Message}");
            _writer.Flush();
        }
    }
    
}
