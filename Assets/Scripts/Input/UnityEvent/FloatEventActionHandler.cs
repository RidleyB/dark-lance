using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FloatEventActionHandler : UnityEventActionHandlerBase
{
    [SerializeField]
    FloatUnityEvent unityEvent;

    protected override void OnInputInvoke(CallbackContext a_context)
    {
        unityEvent.Invoke(a_context.ReadValue<float>());
    }
}
