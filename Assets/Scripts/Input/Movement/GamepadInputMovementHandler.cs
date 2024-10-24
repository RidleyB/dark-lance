using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace arg
{
    public class GamepadInputMovementHandler : IInputMovementHandler
    {
        [OdinSerialize]
        private InputActionReference movementInput;

        [OdinSerialize]
        private InputActionReference lookInput;

        [OdinSerialize]
        private InputActionReference anyInput;

        public void EnableInput()
        {
            movementInput.action.actionMap.Enable();
            movementInput.action.Enable();
        }

        public void DisableInput()
        {
            movementInput.action.Disable();
            movementInput.action.actionMap.Disable();
        }

        public Vector2 GetMovementDirection()
        {
            return movementInput.action.ReadValue<Vector2>();
        }

        public bool IsPressed()
        {
            return movementInput.action.IsPressed();
        }

        public void Sub(InputAction a_inputActions)
        {
            a_inputActions.Subscribe(movementInput);
        }

        public void Unsub(InputAction a_inputActions)
        {
            a_inputActions.Unsubscribe(movementInput);
        }

        public void SubToAny(InputAction a_inputActions)
        {
            a_inputActions.Subscribe(anyInput.action);
        }

        public void UnsubToAny(InputAction a_inputActions)
        {
            a_inputActions.Unsubscribe(anyInput.action);
        }

        public bool GetAnyPressed()
        {
            return anyInput.action.IsPressed();
        }

        public Vector2 GetLookAxis()
        {
            return lookInput.action.ReadValue<Vector2>();
        }
    }
}
