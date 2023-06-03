using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }
public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public CustomGameEvent onEventTriggered;
    void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnEventTriggered(Component sender, object data)
    {
        onEventTriggered.Invoke(sender, data);
    }
}
