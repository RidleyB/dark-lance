using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace arg
{
    public class InputReferenceUnityEvent : UnityEvent<InputActionReference> { }

    public abstract class InputController<T> : SerializedMonoBehaviour where T : class, IInputHandler
    {
        [Header("Input")]
        [OdinSerialize]
        private T keyboardInputHandler;

        [OdinSerialize]
        private T gamepadInputHandler;

        protected T currentInputHandler;

        protected virtual void OnEnable()
        {
            if (keyboardInputHandler == null && gamepadInputHandler == null)
            {
                Debug.LogError("No input handlers. Deactivating.");
                enabled = false;
                return;
            }

            if (keyboardInputHandler != null && gamepadInputHandler == null)
                currentInputHandler = keyboardInputHandler;

            else if (gamepadInputHandler != null && keyboardInputHandler == null)
                currentInputHandler = gamepadInputHandler;

            else
                currentInputHandler = keyboardInputHandler;

            EnableInput();
        }

        protected virtual void OnDisable()
        {
            DisableInput();
        }

        protected virtual void Update()
        {
            if (!Application.isFocused)
                return;

            HandleInputSwap();
        }

        void HandleInputSwap()
        {
            if (keyboardInputHandler != null && currentInputHandler != keyboardInputHandler && keyboardInputHandler.GetAnyPressed())
                SwapToKeyboardInput(default);

            else if (gamepadInputHandler != null && currentInputHandler != gamepadInputHandler && gamepadInputHandler.GetAnyPressed())
                SwapToGamepadInput(default);
        }

        protected virtual void EnableInput()
        {
            if (keyboardInputHandler != null)
                keyboardInputHandler.EnableInput();

            if (gamepadInputHandler != null)
                gamepadInputHandler.EnableInput();
        }

        protected virtual void DisableInput()
        {
            if (keyboardInputHandler != null)
                keyboardInputHandler.DisableInput();

            if (gamepadInputHandler != null)
                gamepadInputHandler.DisableInput();
        }

        protected virtual void SwapToGamepadInput(UnityEngine.InputSystem.InputAction.CallbackContext a_callback)
        {
            currentInputHandler = gamepadInputHandler;
            Debug.Log("Swapped to gamepad.");
        }

        protected virtual void SwapToKeyboardInput(UnityEngine.InputSystem.InputAction.CallbackContext a_callback)
        {
            currentInputHandler = keyboardInputHandler;
            Debug.Log("Swapped to keyboard.");
        }
    }
}