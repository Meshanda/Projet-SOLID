using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameWithSource")]
public class GameEventWithSource : ScriptableObject
{
    [SerializeField]
    private List<GameEventWithSourceListener> _listeners;

    public void Raise(Object source)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised(source);
        }
    }

    public void RegisterListener(GameEventWithSourceListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GameEventWithSourceListener listener)
    {
        _listeners.Remove(listener);
    }

}
