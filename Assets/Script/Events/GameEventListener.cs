using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : OrdonedMonoBehaviour
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private UnityEvent onEventRaised;

    public void OnEventRaised()
    {
        onEventRaised.Invoke();
    }

    public override void DoAwake()
    {
        _event.RegisterListener(this);
    }

    public override void DoUpdate()
    {

    }

    private void OnDisable()
    {
        _event.UnregisterListener(this);
    }
}
