using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Credentials")]
public class TwitchAcountCredentials : ScriptableObject
{
    [SerializeField] private string _username;
    [SerializeField] private string _twitchAcountName;
    [SerializeField] private string _oauthPassword;
    
    public string Username { get => _username; set => _username = value; }
    public string TwitchAcountName{ get => _twitchAcountName; set => _twitchAcountName = value; }
    public string OauthPassword{ get => _oauthPassword ; set => _oauthPassword = value; }

    public TwitchAcountCredentials()
    {
        Username = "testjeuchattwitch";
        TwitchAcountName = "testjeuchattwitch";
        OauthPassword = "oauth:t6g5wagmm9yk9r0zuyquh1q1mlysgp";
    }
}
