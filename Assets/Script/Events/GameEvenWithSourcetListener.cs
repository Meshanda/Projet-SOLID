using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class GameEventWithSourceListener : MonoBehaviour
{
    [SerializeField]
    private GameEventWithSource _event;

    [SerializeField]
    private UnityEvent<Object, Object> _onEventRaised;

    public void OnEventRaised(Object source)
    {
        _onEventRaised.Invoke(_event, source);
    }

    private void OnEnable()
    {
        _event.RegisterListener(this);
    }

    private void OnDisable()
    {
        _event.UnregisterListener(this);
    }
}
