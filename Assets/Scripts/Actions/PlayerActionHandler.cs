using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[CreateAssetMenu(menuName = "ARG/Player Action Handler")]
public class PlayerActionHandler : SerializedScriptableObject
{
    public InputActionReference inputActionRef;
    public PlayerAction playerAction;
    public bool readValueEachFrame;
    private InputActionCallback actionCallback;

    public void EnableInput()
    {
        if (!inputActionRef.action.actionMap.enabled)
            inputActionRef.action.actionMap.Enable();

        inputActionRef.action.Enable();
        inputActionRef.action.started += StartAction;
        inputActionRef.action.canceled += CancelAction;

        if (!readValueEachFrame)
            inputActionRef.action.performed += PerformAction;
    }

    public void DisableInput()
    {
        inputActionRef.action.Disable();

        inputActionRef.action.started -= StartAction;
        inputActionRef.action.canceled -= CancelAction;

        if (!readValueEachFrame)
            inputActionRef.action.performed -= PerformAction;
    }

    void StartAction(CallbackContext a_callback)
    {
        playerAction.Start(GetCallback(a_callback));
    }

    void PerformAction(CallbackContext a_callback)
    {
        playerAction.Perform(GetCallback(a_callback));
    }

    void CancelAction(CallbackContext a_callback)
    {
        playerAction.Cancel(GetCallback(a_callback));
    }

    public InputActionCallback GetCallback(CallbackContext? a_callback)
    {
        if (actionCallback == null)
            actionCallback = new InputActionCallback(inputActionRef);

        InputCallbackState state;

        if (a_callback == null)
            state = InputCallbackState.Performed;
        else
        {
            switch (a_callback.Value.phase)
            {
                case InputActionPhase.Started:
                    state = InputCallbackState.Started;
                    break;
                case InputActionPhase.Performed:
                    state = InputCallbackState.Performed;
                    break;
                case InputActionPhase.Canceled:
                    state = InputCallbackState.Canceled;
                    break;
                default:
                    throw new Exception();
            }
        }


        actionCallback.SetState(state);
        return actionCallback;
    }

    public bool IsPressed()
    {
        return inputActionRef.action.IsPressed();
    }

    public object ReadValue()
    {
        return inputActionRef.action.ReadValueAsObject();
    }

    public T ReadValue<T>() where T : struct
    {
        return inputActionRef.action.ReadValue<T>();
    }

    public void Update()
    {
        if (readValueEachFrame && inputActionRef.action.IsPressed())
            playerAction.Perform(GetCallback(default));
    }
}