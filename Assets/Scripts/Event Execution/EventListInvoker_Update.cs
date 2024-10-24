using Sirenix.Serialization;

public class EventListInvoker_Update : EventListInvoker
{
    protected override void ExecuteEvents()
    {
        foreach (IListElement eventElement in events)
        {
            if (!eventElement.IsEnabled())
                continue;

            eventElement.Invoke();
        }
    }

    void Update()
    {
        ExecuteEvents();
    }
}