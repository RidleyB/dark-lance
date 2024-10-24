using arg.events;
using UnityEngine.Events;

public enum InvokeType
{
    OnEnable,
    OnEvent,
    OnUpdate
}

public interface IListElement
{
    void Invoke();
    bool IsEnabled();
}

public struct EventListElement : IListElement
{
    public EventObject eventObject;
    public bool enabled;

    public void Invoke()
    {
        if (eventObject == null)
            return;

        eventObject.Invoke();
    }

    public bool IsEnabled() => enabled;
}

public struct UnityEventListElement : IListElement
{
    public UnityEvent eventObject;
    public bool enabled;

    public void Invoke()
    {
        if (eventObject == null)
            return;

        eventObject.Invoke();
    }

    public bool IsEnabled() => enabled;
}