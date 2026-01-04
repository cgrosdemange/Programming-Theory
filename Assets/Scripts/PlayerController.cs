using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vehicle vehicle;

    private void Awake()
    {
        vehicle = GetComponent<Vehicle>();
    }

    private void Update()
    {
        float throttle = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");

        vehicle.SetInput(throttle, steering);

        /*
        // Activate Nitro (Racing Car only)
        if (Input.GetKeyDown(KeyCode.Space) && vehicle is RacingCar racingCar)
        {
            racingCar.ActivateNitro();
        }
        */
    }
}
