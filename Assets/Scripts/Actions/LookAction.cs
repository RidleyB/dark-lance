using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAction : PlayerAction
{
    [Header("Look")]
    [OdinSerialize]
    float sensitivity = 0.07f;

    [OdinSerialize]
    TransformData eyeData;

    [OdinSerialize]
    TransformData playerTransform;

    Transform eye => eyeData.data;
    Transform transform => playerTransform.data;

    [Header("Debug")]
    [OdinSerialize, DisableIf("@true")]
    Vector2 currentLookDelta = Vector2.zero;

    [OdinSerialize, DisableIf("@true")]
    Vector2 currentLookDeltaVelocity = Vector2.zero;

    [OdinSerialize, DisableIf("@true")]
    float lookSmoothTime = 0.03f;

    [OdinSerialize, DisableIf("@true")]
    float cameraPitch;

    protected override void _Start(InputActionCallback a_callback) { }

    protected override void _Cancel(InputActionCallback a_callback) { }

    protected override void _Perform(InputActionCallback a_callback)
    {
        currentLookDelta = Vector2.SmoothDamp(currentLookDelta, a_callback.ReadValue<Vector2>(), ref currentLookDeltaVelocity, lookSmoothTime);
        cameraPitch -= currentLookDelta.y * sensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        eye.localEulerAngles = (Vector3.right * cameraPitch) + (Vector3.up * (currentLookDelta.x * sensitivity));
        transform.Rotate(Vector3.up * (currentLookDelta.x * sensitivity));
    }

}
