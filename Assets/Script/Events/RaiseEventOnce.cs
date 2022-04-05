using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnce : MonoBehaviour
{
    [SerializeField] private GameStateEvent _gameStateEvent;

    private void Start()
    {
        _gameStateEvent.Raise();
    }
}
