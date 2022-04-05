using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class TileEventListener : OrdonedMonoBehaviour
{
    [SerializeField]
    private TileEvent _event;

    [SerializeField]
    private UnityEvent<Vector2Int> _onEventRaised;

    public void OnEventRaised(Vector2Int Position)
    {
        _onEventRaised.Invoke(Position);
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
