using Sirenix.Serialization;
using System;
using UnityEngine;

[Flags]
enum InvokeTime
{
    None = 0x0000,
    Start = 0x0001,
    Perform = 0x0010,
    Cancel = 0x0100
}

public class EventAction : PlayerAction
{
    [Tooltip("At what point during the input event will the EventObject invoke (Use Perform for held actions).")]
    [OdinSerialize]
    InvokeTime eventInvokeTime;

    [OdinSerialize]
    InputEvent eventAction;

    protected override void _Start(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Start) == 0)
            return;

        eventAction.Invoke(a_callback);
    }

    protected override void _Perform(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Perform) == 0) 
            return;

        eventAction.Invoke(a_callback);
    }

    protected override void _Cancel(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Cancel) == 0) 
            return;

        eventAction.Invoke(a_callback);
    }
}
