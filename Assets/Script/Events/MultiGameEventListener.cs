using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct eventData
{
    public GameEvent _event;
    public GameEventListener _onEventRaised;
}

public class MultiGameEventListener : MonoBehaviour
{
   public List<GameEventListener> _eventsList;


    
    private void OnEnable()
    {
        foreach (var tupleEvent in _eventsList)
        {
            //tupleEvent._event.RegisterListener(tupleEvent._onEventRaised);
        }
    }

    private void OnDisable()
    {
        foreach (var tupleEvent in _eventsList)
        {
            //tupleEvent._event.UnregisterListener(tupleEvent._onEventRaised);
        }
    }
}
