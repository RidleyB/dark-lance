using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class MoveAction : PlayerAction
{
    [OdinSerialize]
    TransformData playerTransform;
    Transform transform => playerTransform.data;

    [OdinSerialize]
    FloatData speedModifier;

    [OdinSerialize]
    FloatData currentSpeed;

    [OdinSerialize]
    FloatData currentYSpeed;

    [OdinSerialize]
    float moveSmoothTime = 0.07f;

    [OdinSerialize]
    Vector2Data movementDirection;

    [OdinSerialize]
    Vector3Data lastGroundLocation;

    [Header("Debug")]
    [OdinSerialize, DisableIf("@true")]
    Vector2 currentDirection = Vector2.zero;

    [OdinSerialize, DisableIf("@true")]
    Vector2 _currentDirectionVelocity = Vector2.zero;

    float lastMoveSpeedWhileGrounded;

    CharacterController _controller;
    CharacterController controller
    {
        get
        {
            if(_controller == null)
                _controller = playerTransform.data.GetComponent<CharacterController>();

            return _controller;
        }
    }

    protected override void _Start(InputActionCallback a_callback) { }

    /// <summary>
    /// Calls perform to zero out movement data.
    /// </summary>
    /// <param name="a_callback"></param>
    protected override void _Cancel(InputActionCallback a_callback) => _Perform(a_callback);

    protected override void _Perform(InputActionCallback a_callback)
    {
        float speed;
        // use stored ground speed if we're in the air
        if (!controller.isGrounded)
            speed = lastMoveSpeedWhileGrounded * speedModifier.data;
        // otherwise we're free to use our current ground speed
        else
            speed = currentSpeed.data * speedModifier.data;

        movementDirection.data = a_callback.ReadValue<Vector2>().normalized;
        currentDirection = Vector2.SmoothDamp(currentDirection, movementDirection.data, ref _currentDirectionVelocity, moveSmoothTime);
        Vector3 velocity = (transform.forward * currentDirection.y + transform.right * currentDirection.x) * speed;
        controller.Move(velocity * Time.deltaTime);

        // store ground speed if we're grounded
        if (controller.isGrounded)
        {
            lastMoveSpeedWhileGrounded = currentSpeed.data;
            lastGroundLocation.data = controller.transform.position;
        }

        speedModifier.ResetData();
    }

}
