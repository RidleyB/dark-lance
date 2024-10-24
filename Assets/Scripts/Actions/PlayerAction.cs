using Sirenix.Serialization;
using UnityEngine;

public abstract class PlayerAction
{
    [OdinSerialize]
    ActionCooldown cooldown;

    protected abstract void _Start(InputActionCallback a_callback);
    protected abstract void _Perform(InputActionCallback a_callback);
    protected abstract void _Cancel(InputActionCallback a_callback);
    protected virtual bool _CanPerform() => true;

    public void Start(InputActionCallback a_callback)
    {
        if (!CanUseAction())
            return;

        _Start(a_callback);

        if (cooldown != null)
            cooldown.StartCooldown();
    }

    public void Perform(InputActionCallback a_callback)
    {
        _Perform(a_callback);
    }

    public void Cancel(InputActionCallback a_callback)
    {
        _Cancel(a_callback);
    }

    public bool CanUseAction()
    {
        if (cooldown != null && cooldown.onCooldown)
        {
            Debug.Log($"On cooldown, {cooldown.remaining}s remaining");
            return false;
        }

        return _CanPerform();
    }
}