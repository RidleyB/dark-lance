using arg.events;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Events/Input")]
public class InputEvent : EventObject<InputActionCallback> { }

public class InputEventListener : EventListener<InputActionCallback> { }