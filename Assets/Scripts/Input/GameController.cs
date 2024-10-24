using arg;

public class GameController : InputController<KIGameHandler> 
{
    protected override void Update()
    {
        base.Update();
        currentInputHandler.Update();
    }
}