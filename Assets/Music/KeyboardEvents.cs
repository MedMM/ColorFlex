using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardEvents : MonoBehaviour
{
    [SerializeField] KeyedEvent[] events;
    [Serializable] struct KeyedEvent
    {
        public KeyCode keyCode;
        public UnityEvent unityEvent;
    }

    private void Update()
    {
        foreach(KeyedEvent a in events)
        {
            if (Input.GetKeyDown(a.keyCode))
            {
                a.unityEvent.Invoke();
            }
        }
    }
}
