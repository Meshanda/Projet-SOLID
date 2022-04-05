using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateWinner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private StringVariable winnerName;
    [SerializeField] private StringVariable noWinner;

    private void Start()
    {
        if (winnerName.Value != "")
        {
            text.text = "Winner: \n" + winnerName.Value;
        }
        else
        {
            text.text = noWinner.Value;
        }
    }
}
