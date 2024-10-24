using arg.events;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Events/Float")]
public class FloatEvent : EventObject<float> { }

public class FloatEventListener : EventListener<float> { }
