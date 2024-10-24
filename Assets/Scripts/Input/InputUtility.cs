using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum InputCallbackState
{
    None,
    Started,
    Performed,
    Canceled,
}

public class InputActionCallback
{
    InputActionReference _actionRef;
    InputCallbackState _state;
    public InputCallbackState state => _state;
    public T ReadValue<T>() where T : struct => _actionRef.action.ReadValue<T>();
    public object ReadValueAsObject() => _actionRef.action.ReadValueAsObject();
    internal void SetState(InputCallbackState a_state) => _state = a_state;
    public InputActionCallback(InputActionReference a_ref) => _actionRef = a_ref;
}

public class InputAction
{
    public readonly Action<UnityEngine.InputSystem.InputAction.CallbackContext> started;
    public readonly Action<UnityEngine.InputSystem.InputAction.CallbackContext> performed;
    public readonly Action<UnityEngine.InputSystem.InputAction.CallbackContext> canceled;

    public InputAction(Action<UnityEngine.InputSystem.InputAction.CallbackContext> a_onStarted, Action<UnityEngine.InputSystem.InputAction.CallbackContext> a_onPerformed = null, Action<UnityEngine.InputSystem.InputAction.CallbackContext> a_onCanceled = null)
    {
        started = a_onStarted;
        performed = a_onPerformed;
        canceled = a_onCanceled;
    }

    public void Subscribe(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        SubscribeToStarted(a_inputAction);
        SubscribeToPerformed(a_inputAction);
        SubscribeToCanceled(a_inputAction);
    }

    public void Unsubscribe(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        SubscribeToStarted(a_inputAction);
        SubscribeToPerformed(a_inputAction);
        SubscribeToCanceled(a_inputAction);
    }

    public void SubscribeToStarted(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        if (started == null)
            return;

        if (a_inputAction == null)
        {
            Debug.LogError("Input action was null");
            return;
        }

        a_inputAction.started += started;
    }

    public void SubscribeToPerformed(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        if (performed == null)
            return;

        if (a_inputAction == null)
        {
            Debug.LogError("Input action was null");
            return;
        }

        a_inputAction.performed += performed;
    }

    public void SubscribeToCanceled(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        if (canceled == null)
            return;

        if (a_inputAction == null)
        {
            Debug.LogError("Input action was null");
            return;
        }

        a_inputAction.canceled += canceled;
    }

    public void UnsubscribeToStarted(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        if (started == null)
            return;

        if (a_inputAction == null)
        {
            Debug.LogError("Input action was null");
            return;
        }

        a_inputAction.started -= started;
    }

    public void UnsubscribeToPerformed(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        if (performed == null)
            return;

        if (a_inputAction == null)
        {
            Debug.LogError("Input action was null");
            return;
        }

        a_inputAction.performed -= performed;
    }

    public void UnsubscribeToCanceled(UnityEngine.InputSystem.InputAction a_inputAction)
    {
        if (canceled == null)
            return;

        if (a_inputAction == null)
        {
            Debug.LogError("Input action was null");
            return;
        }

        a_inputAction.canceled -= canceled;
    }
}

public interface IInputHandler
{
    void EnableInput();
    void DisableInput();
    bool GetAnyPressed();
}

public interface IInputMovementHandler : IInputHandler, IMovementHandler
{
    bool IsPressed();
    void Sub(InputAction a_inputActions);
    void Unsub(InputAction a_inputActions);
}

public interface IInputActionHandler : IInputHandler
{
    bool IsInteractPressed();
    void SubToInteract(InputAction a_inputActions);
    void UnsubToInteract(InputAction a_inputActions);
}

public interface IMovementHandler
{
    Vector2 GetMovementDirection();
    Vector2 GetLookAxis();
}