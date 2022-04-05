using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Player/Local/JoinLocaly")]
public class JoinLocaly : ScriptableObject
{
    [SerializeField] private PlayerClasses playerClasses;
    [SerializeField] private PlayerCommand joinCommand;
    [SerializeField] private TwitchAcountCredentials credentials;
    
    public void JoinLocal(TextMeshProUGUI dropdownValue)
    {
        PlayerClass playerClass = playerClasses.AvailableClasses[playerClasses.ClassIndex(dropdownValue.text)];
        var joinCopy = (JoinPlayerCommand) joinCommand;
        joinCopy.PlayerClass = playerClass;
        joinCopy.Execute(credentials.TwitchAcountName);
    }
}
