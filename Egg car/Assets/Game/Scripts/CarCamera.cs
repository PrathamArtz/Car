using UnityEngine;

public class CarCamera : MonoBehaviour
{
    public Transform target; // Assign the truck here
    public Vector3 offset = new Vector3(0, 3, -6); // Position offset from truck
    public float smoothTime = 0.2f; // Smoothing time for movement

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    private void FixedUpdate()
    {
        if (target == null) return;

        // Compute the target position
        targetPosition = target.position + target.TransformDirection(offset);
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Rotate the camera to always look at the truck
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}
