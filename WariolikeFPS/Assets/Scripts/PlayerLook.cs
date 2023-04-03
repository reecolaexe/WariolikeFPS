using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerCamera;
    public Vector2 mouseSensitivity;
    private Vector2 xyRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseInput = new Vector2 { x = Input.GetAxisRaw("Mouse X"), y = Input.GetAxisRaw("Mouse Y") };
        xyRotation.x -= mouseInput.y * mouseSensitivity.y;
        xyRotation.y += mouseInput.x * mouseSensitivity.x;
        xyRotation.x = Mathf.Clamp(xyRotation.x, -90f, 90f);
        transform.eulerAngles = new Vector3(0f, xyRotation.y, 0f);
        playerCamera.localEulerAngles = new Vector3(xyRotation.x, 0f, 0f);
    }
}
