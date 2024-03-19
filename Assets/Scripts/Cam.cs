using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target; // The car's transform
    public Vector3 offset; // Offset from the car's position
    public float smoothSpeed = 0.125f; // Adjust for smoother following

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not set for CameraFollow script.");
            return;
        }

        // Compute the new position of the camera
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position and rotation
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}