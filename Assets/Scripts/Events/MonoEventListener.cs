using arg.events;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventListener : SerializedMonoBehaviour
{
    [SerializeField]
    EventObject eventObject;
    EventListener eventListener;

    [SerializeField]
    UnityEvent unityEvent;

    void OnEnable()
    {
        eventListener = new EventListener();
        eventListener.Sub(eventObject, Invoke);
    }

    void OnDisable()
    {
        eventListener.Unsub();
    }

    public void Invoke()
    {
        unityEvent.Invoke();
    }
}
