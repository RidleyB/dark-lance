using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class UnityEventAction : PlayerAction
{
    [Tooltip("At what point during the input event will the EventObject invoke (Use Perform for held actions).")]
    [OdinSerialize]
    InvokeTime eventInvokeTime;

    [OdinSerialize]
    UnityEvent unityEvent;

    protected override void _Start(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Start) == 0)
            return;

        unityEvent.Invoke();
    }

    protected override void _Perform(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Perform) == 0)
            return;

        unityEvent.Invoke();
    }

    protected override void _Cancel(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Cancel) == 0)
            return;

        unityEvent.Invoke();
    }
}

public abstract class UnityEventAction<T> : PlayerAction
{
    [Tooltip("At what point during the input event will the EventObject invoke (Use Perform for held actions).")]
    [OdinSerialize]
    InvokeTime eventInvokeTime;

    [OdinSerialize]
    UnityEvent<T> unityEvent;

    protected override void _Start(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Start) == 0)
            return;
    
        unityEvent.Invoke((T)a_callback.ReadValueAsObject());
    }

    protected override void _Perform(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Perform) == 0)
            return;

        unityEvent.Invoke((T)a_callback.ReadValueAsObject());
    }

    protected override void _Cancel(InputActionCallback a_callback)
    {
        if ((eventInvokeTime & InvokeTime.Cancel) == 0)
            return;

        unityEvent.Invoke((T)a_callback.ReadValueAsObject());
    }
}

public class IntUnityEventAction : UnityEventAction<int> { }

public class FloatUnityEventAction : UnityEventAction<float> { }

public class BoolUnityEventAction : UnityEventAction<bool> { }

public class Axis2DUnityEventAction : UnityEventAction<Vector2> { }