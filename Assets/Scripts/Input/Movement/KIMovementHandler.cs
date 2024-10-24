using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace arg
{
    public class KIMovementHandler : IInputMovementHandler
    {
        [OdinSerialize]
        InputActionReference forwardInput;

        [OdinSerialize]
        InputActionReference backwardInput;

        [OdinSerialize]
        InputActionReference leftInput;

        [OdinSerialize]
        InputActionReference rightInput;

        [OdinSerialize]
        InputActionReference mouseInput;

        [OdinSerialize]
        InputActionReference anyInput;

        public void EnableInput()
        {
            forwardInput.action.actionMap.Enable();
            forwardInput.action.Enable();
            mouseInput.action.Enable();
            backwardInput.action.Enable();
            leftInput.action.Enable();
            rightInput.action.Enable();
        }

        public void DisableInput()
        {
            mouseInput.action.Disable();
            forwardInput.action.Disable();
            backwardInput.action.Disable();
            leftInput.action.Disable();
            rightInput.action.Disable();
            forwardInput.action.actionMap.Disable();
        }

        public Vector2 GetMovementDirection()
        {
            bool forward = forwardInput.action.IsPressed();
            bool backward = backwardInput.action.IsPressed();
            bool left = leftInput.action.IsPressed();
            bool right = rightInput.action.IsPressed();

            Vector2 direction = Vector2.zero;
            if (forward || backward || left || right)
            {
                if (forward)
                    direction.y += 1;
                if (backward)
                    direction.y -= 1;
                if (left)
                    direction.x -= 1;
                if (right)
                    direction.x += 1;
            }

            if (direction.magnitude > 1)
                direction.Normalize();

            return direction;
        }

        public bool IsPressed()
        {
            return forwardInput.action.IsPressed() || backwardInput.action.IsPressed() || leftInput.action.IsPressed() || rightInput.action.IsPressed();
        }

        public void Sub(InputAction a_inputActions)
        {
            a_inputActions.Subscribe(forwardInput);
            a_inputActions.Subscribe(backwardInput);
            a_inputActions.Subscribe(leftInput);
            a_inputActions.Subscribe(rightInput);
        }

        public void Unsub(InputAction a_inputActions)
        {
            a_inputActions.Unsubscribe(forwardInput);
            a_inputActions.Unsubscribe(backwardInput);
            a_inputActions.Unsubscribe(leftInput);
            a_inputActions.Unsubscribe(rightInput);
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
            return mouseInput.action.ReadValue<Vector2>();
        }
    }
}