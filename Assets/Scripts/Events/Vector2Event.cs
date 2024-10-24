using arg.events;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Events/Vector2")]
public class Vector2Event : EventObject<Vector2> { }

public class Vector2EventListener : EventListener<Vector2> { }