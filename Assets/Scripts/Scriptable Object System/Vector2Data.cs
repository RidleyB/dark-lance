using arg.data;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Data/Vector2")]
public class Vector2Data : DataObject<Vector2>
{
    public float x => data.x;
    public float y => data.y;
}
