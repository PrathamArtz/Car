using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject car;
    public Vector3 cameraOffset = new Vector3(0, 3.84f, -7f);
    public float smoothSpeed = 5f; // Speed for smooth camera movement
    public float fixedXRotation = 10f; // Set this to your preferred X rotation angle

    void LateUpdate()
    {
        // Calculate desired position
        Vector3 targetPosition = car.transform.position + car.transform.rotation * cameraOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Get the car's Y rotation but keep a fixed X rotation
        Quaternion targetRotation = Quaternion.Euler(fixedXRotation, car.transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}
