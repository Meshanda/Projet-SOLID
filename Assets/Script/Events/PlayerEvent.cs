using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Player")]
public class PlayerEvent : ScriptableObject
{
    [SerializeField]
    private List<PlayerEventListener> _listeners;

    public void Raise(int Index)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised(Index);
        }
    }

    public void RegisterListener(PlayerEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(PlayerEventListener listener)
    {
        _listeners.Remove(listener);
    }

}
