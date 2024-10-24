using arg.events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class EventBoot : SerializedMonoBehaviour
{
    [OdinSerialize]
    EventObject eventBoot;

    void Start()
    {
        eventBoot.Invoke();
    }
}
