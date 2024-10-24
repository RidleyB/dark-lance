public class EventListInvoker_OnDestroy : EventListInvoker
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

    void OnDestroy()
    {
        ExecuteEvents();
    }
}
