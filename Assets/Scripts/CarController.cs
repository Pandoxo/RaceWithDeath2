using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;

    private float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle;
    private bool isReversing = false;

    private Rigidbody2D carRb;

    void Awake()
    {
        carRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }

    void ApplyEngineForce()
    {
        if (accelerationInput == 0)
        {
            carRb.linearDamping = Mathf.Lerp(carRb.linearDamping, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRb.linearDamping = 0;
        }

        Vector2 engineForceVector = transform.up * accelerationFactor * accelerationInput;

        // Check if the car is reversing based on velocity and acceleration input
        if (Vector2.Dot(transform.up, carRb.linearVelocity) < 0)
        {
            isReversing = true;
        }
        else
        {
            isReversing = false;
        }

        carRb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRb.linearVelocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRb.linearVelocity, transform.right);

        carRb.linearVelocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public float GetLateralVelocity()
    {
        return Vector2.Dot(transform.right, carRb.linearVelocity);
    }

    public float GetVelocityMagnitude()
    {
        return carRb.linearVelocity.magnitude;
    }

    public bool IsTireScreeching(out float lateralVelocity, out bool isBraking)
    {
        lateralVelocity = GetLateralVelocity();
        isBraking = false;

        if (accelerationInput < 0 && carRb.linearVelocity.magnitude > 1f)
        {
            isBraking = true;
            return true;
        }

        if (Mathf.Abs(lateralVelocity) > 2.0)
        {
            return true;
        }
        return false;
    }

    void ApplySteering()
    {
        float minSpeedBeforeTurning = carRb.linearVelocity.magnitude / 8;
        minSpeedBeforeTurning = Mathf.Clamp01(minSpeedBeforeTurning);

        // Adjust steering based on reversing state
        float steeringDirection = isReversing ? -1 : 1;

        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeTurning * steeringDirection;
        carRb.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        accelerationInput = inputVector.y;
        steeringInput = inputVector.x;
    }
}

