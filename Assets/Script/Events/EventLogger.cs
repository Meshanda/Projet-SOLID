using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    void Logger(Object _event, Object source)
    {
        Debug.Log($"{source.name} sent an event {_event.name}");
    }

}
