using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    public delegate void EventReceiver(params object[] parameterContainer);
    private static Dictionary<string, EventReceiver> _events;

    public static void SubscribeToEvent(string e, EventReceiver listener)
    {
        if (_events == null)
            _events = new Dictionary<string, EventReceiver>();
        if (!_events.ContainsKey(e))
            _events.Add(e, null);
        _events[e] += listener;
    }

    public static void UnsubscribeToEvent(string e, EventReceiver listener)
    {
        if (_events != null && _events.ContainsKey(e))
            _events[e] -= listener;
    }

    public static void TriggerEvent(string e)
    {
        TriggerEvent(e, null);
    }

    public static void TriggerEvent(string e, params object[] parameters)
    {
        if(_events != null && _events.ContainsKey(e) && _events[e] != null)
        {
            _events[e](parameters);
        }
    }
}
