using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected float speed;
    [SerializeField] protected float steeringAngle;

    [Header("Fuel")]
    [SerializeField] protected float maxFuel = 100f;
    [SerializeField] protected float fuelConsumptionRate = 1f;

    [Header("Wheels")]
    [SerializeField] protected GameObject frontLeftWheel;
    [SerializeField] protected GameObject frontRightWheel;
    [SerializeField] protected GameObject rearLeftWheel;
    [SerializeField] protected GameObject rearRightWheel;

    protected float throttle;
    protected float steering;
    protected float currentFuel;
    
    protected virtual void Awake()
    {
        currentFuel = maxFuel;
    }

    public virtual void SetInput(float throttle, float steering)
    {
        this.throttle = throttle;
        this.steering = steering;
    }

    protected virtual void Update()
    {
        if (HasFuel())
        {
            ConsumeFuel();
            Move();
            Steer();
        }
    }

    protected bool HasFuel()
    {
        return currentFuel > 0f;
    }

    protected virtual void ConsumeFuel()
    {
        if (Mathf.Abs(throttle) > 0.1f)
        {
            currentFuel -= fuelConsumptionRate * Time.deltaTime;
            currentFuel = Mathf.Max(currentFuel, 0f);
        }
    }

    protected abstract void Move();
    protected abstract void Steer();

    // Read-Only public properties
    public float FuelPercent => currentFuel / maxFuel;
    public float Steering => steering;
}