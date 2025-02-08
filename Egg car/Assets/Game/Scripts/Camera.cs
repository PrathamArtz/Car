using UnityEngine;

public class Camera : MonoBehaviour
{
   
    public Transform car; // The car object the camera will follow
    public Vector3 offset = new Vector3(0, 5, -10); // Fixed world-space offset
    public float followSpeed = 10f; // How quickly the camera follows the car
    public float rotationSpeed = 5f; // How smoothly the camera rotates to look at the car

    void LateUpdate()
    {
        if (car == null)
        {
            Debug.LogWarning("Car Transform is not assigned!");
            return;
        }

        // Target position for the camera (maintaining world-space offset)
        Vector3 targetPosition = car.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Rotate the camera to look at the car
        Quaternion targetRotation = Quaternion.LookRotation(car.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
