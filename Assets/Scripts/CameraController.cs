using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform focalPoint;
    public Vector3 offset;
    public float mouseSensitivity;
    public Transform pivot;

    void Start()
    {
        offset = focalPoint.position - transform.position;

        // pivot used as intermediate object to rotate camera vertically instead of directly the player (prevent player from rotating verticaly)
        pivot.transform.position = focalPoint.transform.position;
        pivot.transform.parent = focalPoint.transform;

        // hide mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    // use LateUpdate to prevent camera jerking
    void LateUpdate()
    {
        // get mouseX position and rotate player on its Y-axis based on the value to move horizontaly
        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        focalPoint.Rotate(0, horizontal, 0);

        // get mouseY position and rotate pivot (prevent player from rotating verticaly) on its X-axis based on the value to move verticaly
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
        pivot.Rotate(-vertical, 0, 0);

        // rotating camera to follow the players rotation
        // converting player roation into quaternion angle to resposition the camera
        float cameraAdjustY = focalPoint.eulerAngles.y;
        float cameraAdjustX = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(cameraAdjustX, cameraAdjustY, 0);
        transform.position = focalPoint.position - (rotation * offset);

        // stop camera from going below the stage by zooming in on player when too low
        if(transform.position.y < focalPoint.position.y) {
            transform.position = new Vector3(transform.position.x, focalPoint.position.y - .5f, transform.position.z);
        }

        // repositioning the camera with the offset
        transform.LookAt(focalPoint);
    }
}
