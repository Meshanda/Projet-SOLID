using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseSingleEvent : MonoBehaviour
{
    [SerializeField] private GameEvent _event;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _event.Raise();
            Debug.Log($"{_event.name} raised");
        }
    }
}
