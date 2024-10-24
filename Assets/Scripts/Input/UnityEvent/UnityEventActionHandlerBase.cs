using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public abstract class UnityEventActionHandlerBase : MonoBehaviour
{
    [SerializeField]
    protected PlayerActionHandler actionHandler;

    protected virtual void OnEnable()
    {
        actionHandler.inputActionRef.action.performed += OnInputInvoke;
    }

    protected virtual void OnDisable()
    {
        actionHandler.inputActionRef.action.performed -= OnInputInvoke;
    }

    protected abstract void OnInputInvoke(CallbackContext a_context);
}
