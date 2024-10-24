using arg.events;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Events/Int")]
public class IntEvent : EventObject<int> { }

public class IntEventListener : EventListener<int> { }
