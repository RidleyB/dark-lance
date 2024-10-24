using arg.data;
using arg.events;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Scriptable Objects/Bool")]
public class BoolData : DataObject<bool>
{
    /// <summary>
    /// Toggles the value stored in the object. (Triggers NotifyDataChange())
    /// </summary>
    /// <returns>The new toggled value.</returns>
    public bool Toggle() => data = !data;
}

public class BoolEventListener : EventListener<bool> { }
