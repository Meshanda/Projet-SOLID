using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateEventListener : MonoBehaviour
{
    [SerializeField]
    private GameStateEvent _event;

    [SerializeField]
    private List<UnityEvent> _onEventRaised;

    public void OnEventRaised()
    {
        foreach (var eventRaised in _onEventRaised)
        {
            eventRaised.Invoke();   
        }
    }

    public void Awake()
    {
        _event.RegisterListener(this);
    }

    private void OnDisable()
    {
        _event.UnregisterListener(this);
    }
}
