using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField] private PlayerNames playerNames;
    [SerializeField] private PlayerClasses playerClasses;
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private TextMeshProUGUI listText;
    [SerializeField] private FloatVariable playerMaxCount;

    private int _myInt = 0;

    public void UpdateList()
    {
        listText.text += playerNames.Names.Last() + " [" + playerClasses.PlayerClassesList.Last().name + "]" + TextLayout();
        var connectedString = playerNames.Names.Count == 1 ? " player connected" : " players connected";
        
        subtitleText.text = playerNames.Names.Count + "/" + playerMaxCount.Value + connectedString;
    }

    private string TextLayout()
    {
        string myString = "";

        switch (_myInt)
        {
            case 0:
                myString = "\t\t\t";
                break;
            case 1:
                myString = "\t\t\t";
                break;
            case 2:
                myString = "\n";
                break;
        }

        _myInt += 1;
        if (_myInt >= 3) _myInt = 0;
        
        return myString;
    }
}
