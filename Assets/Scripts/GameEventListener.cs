using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomGameEvents : UnityEvent<Component, object>{ }
public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;

    public CustomGameEvents response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        gameEvent.UnRegisterListener(this);
    }
    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender, data);
    }
}
