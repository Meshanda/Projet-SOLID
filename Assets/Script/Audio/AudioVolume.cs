using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private StringVariable VolumeKey;
    private AudioSource[] audioSources;
    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    private void Update()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = PlayerPrefs.GetFloat(VolumeKey.Value) / 100;
        }
    }
}
