using Sirenix.Serialization;
using UnityEngine.InputSystem;

namespace arg
{
    public class KeyboardInputActionHandler : IInputActionHandler
    {
        [OdinSerialize]
        private InputActionReference interactInput;

        [OdinSerialize]
        private InputActionReference anyInput;

        public void EnableInput()
        {
            interactInput.action.actionMap.Enable();
            interactInput.action.Enable();
        }

        public void DisableInput()
        {
            interactInput.action.Disable();
            interactInput.action.actionMap.Disable();
        }

        public bool IsInteractPressed()
        {
            return interactInput.action.IsPressed();
        }

        public void SubToInteract(InputAction a_inputActions)
        {
            a_inputActions.Subscribe(interactInput.action);
        }

        public void UnsubToInteract(InputAction a_inputActions)
        {
            a_inputActions.Unsubscribe(interactInput.action);
        }

        public bool GetAnyPressed()
        {
            return anyInput.action.IsPressed();
        }
    }
}