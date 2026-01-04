/* Assign to the vehicle controlled by Player */
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vehicle vehicle;
    private Vector3 startingPosition = new Vector3(-31, 0, -25);

    private void Awake()
    {
        vehicle = GetComponent<Vehicle>();
        vehicle.transform.position = startingPosition;
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
