using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventListInvoker : SerializedMonoBehaviour
{
    [TextArea]
    [HideLabel]
    [OdinSerialize]
    string description;

    [OdinSerialize]
    [PropertyOrder(1)]
    protected List<IListElement> events;

    #region Editor Only
    [PropertyOrder(0)]
    [Button("Invoke")]
    void Test()
    {
        ExecuteEvents();
    }
    #endregion

    protected abstract void ExecuteEvents();
}