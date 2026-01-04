using UnityEngine;

public class Car : Vehicle
{
    [Header("Wheel Settings")]
    [SerializeField] private float wheelSpinSpeed = 300f;

    private float frontLeftSpinAngle = 0f;
    private float frontRightSpinAngle = 0f;
    private float rearLeftSpinAngle = 0f;
    private float rearRightSpinAngle = 0f;

    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        if (rb == null) return;

        // Déplacement en fonction du Rigidbody
        Vector3 move = transform.forward * speed * throttle * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }

    protected override void Steer()
    {
        if (rb == null) return;

        if (Mathf.Abs(throttle) > 0.01f)
        {
            float moveDir = throttle > 0 ? 1f : -1f;
            Quaternion turn = Quaternion.Euler(0f, steeringAngle * steering * moveDir * Time.deltaTime, 0f);
            rb.MoveRotation(rb.rotation * turn);
        }

        RotateWheels();
    }

    private void RotateWheels()
    {
        float deltaSpin = wheelSpinSpeed * throttle * Time.deltaTime;

        frontLeftSpinAngle += deltaSpin;
        frontRightSpinAngle += deltaSpin;
        rearLeftSpinAngle += deltaSpin;
        rearRightSpinAngle += deltaSpin;

        float steerAngle = steering * 30f;

        if (frontLeftWheel != null)
            frontLeftWheel.transform.localRotation = Quaternion.Euler(frontLeftSpinAngle, steerAngle, 0f);

        if (frontRightWheel != null)
            frontRightWheel.transform.localRotation = Quaternion.Euler(frontRightSpinAngle, steerAngle, 0f);

        if (rearLeftWheel != null)
            rearLeftWheel.transform.localRotation = Quaternion.Euler(rearLeftSpinAngle, 0f, 0f);

        if (rearRightWheel != null)
            rearRightWheel.transform.localRotation = Quaternion.Euler(rearRightSpinAngle, 0f, 0f);
    }
}
