using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Events/GameState/Event")]
public class GameStateEvent : ScriptableObject
{
    [SerializeField]
    private List<GameStateEventListener> _listeners;

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameStateEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GameStateEventListener listener)
    {
        _listeners.Remove(listener);
    }
}
