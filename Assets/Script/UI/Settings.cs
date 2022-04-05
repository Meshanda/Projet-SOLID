using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private TMP_InputField twitchName;
    [SerializeField] private TMP_InputField twitchAuth;
    [SerializeField] private TwitchAcountCredentials twitchCredentials;

    [SerializeField] private StringVariable VolumeKey;

    private void Start()
    {
        float value = PlayerPrefs.GetFloat(VolumeKey.Value);
        slider.value = value;
    }

    private void Update()
    {
        var value = slider.value;
        PlayerPrefs.SetFloat(VolumeKey.Value, slider.value);

        volumeText.text = value.ToString("N0");
    }

    public void SaveSettings()
    {
        if(twitchName.text != "" && twitchAuth.text != "")
        {
            twitchCredentials.Username = twitchName.text.ToLower();
            twitchCredentials.TwitchAcountName = twitchName.text.ToLower();

            twitchCredentials.OauthPassword = twitchAuth.text;
        }
    }
}
