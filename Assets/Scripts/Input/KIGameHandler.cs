using Sirenix.Serialization;
using System.Collections.Generic;

public class KIGameHandler : IInputHandler
{
    [OdinSerialize]
    public List<PlayerActionHandler> actionHandlers;

    public void EnableInput()
    {
        foreach (PlayerActionHandler actionHandler in actionHandlers)
            actionHandler.EnableInput();
    }

    public void DisableInput()
    {
        foreach (PlayerActionHandler actionHandler in actionHandlers)
            actionHandler.DisableInput();
    }

    public bool GetAnyPressed()
    {
        foreach (PlayerActionHandler actionHandler in actionHandlers)
        {
            if (actionHandler.IsPressed())
                return true;
        }

        return false;
    }

    public void Update()
    {
        foreach (PlayerActionHandler actionHandler in actionHandlers)
            actionHandler.Update();
    }
}
