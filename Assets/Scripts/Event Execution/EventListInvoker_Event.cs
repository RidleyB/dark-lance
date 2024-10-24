using arg.events;
using Sirenix.Serialization;
using System;
using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using Unity.EditorCoroutines.Editor;
#endif

public class EventListInvoker_Event : EventListInvoker
{
    [OdinSerialize]
    EventObject e_executeEvents;
    EventListener onExecuteEvents;

    [OdinSerialize]
    bool async;

    protected override void ExecuteEvents()
    {
        if (async)
        {
#if UNITY_EDITOR
            if (Application.isPlaying)
                StartCoroutine(ExecuteAsync());
            else
                EditorCoroutineUtility.StartCoroutine(ExecuteAsync(), this);
#else
            StartCoroutine(ExecuteAsync());
#endif
        }
        else
            Execute();
    }

    void Execute()
    {
        foreach (IListElement eventElement in events)
        {
            if (!eventElement.IsEnabled())
                continue;

            eventElement.Invoke();
        }
    }

    IEnumerator ExecuteAsync()
    {
        foreach (IListElement eventElement in events)
        {
            if (!eventElement.IsEnabled())
                continue;

            eventElement.Invoke();
            yield return null;
        }
    }

    void Awake()
    {
        if (e_executeEvents == null)
            throw new NullReferenceException();

        onExecuteEvents = new EventListener();
        onExecuteEvents.Sub(e_executeEvents, ExecuteEvents);
    }
}