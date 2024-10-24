using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class UnityEventActionHandler : UnityEventActionHandlerBase
{
    [SerializeField]
    UnityEvent unityEvent;

    protected override void OnInputInvoke(CallbackContext a_context)
    {
        unityEvent.Invoke();
    }
}
