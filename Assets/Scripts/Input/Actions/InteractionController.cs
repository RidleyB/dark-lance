using arg.events;
using Sirenix.Serialization;
using UnityEngine.InputSystem;

namespace arg
{
    public class InteractionController : InputController<IInputActionHandler>
    {
        [OdinSerialize]
        private EventObject e_interact;

        protected override void EnableInput()
        {
            base.EnableInput();
            currentInputHandler.SubToInteract(new InputAction(SendInteract));
        }

        private void SendInteract(UnityEngine.InputSystem.InputAction.CallbackContext a_callback)
        {
            if (!a_callback.started)
                return;

            e_interact.Invoke();
        }
    }
}
