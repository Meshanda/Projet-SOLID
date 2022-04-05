using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class PlayerEventListener : OrdonedMonoBehaviour
{
    [SerializeField]
    private PlayerEvent _event;

    [SerializeField]
    private UnityEvent<int> _onEventRaised;

    public void OnEventRaised(int Index)
    {
        _onEventRaised.Invoke(Index);
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
