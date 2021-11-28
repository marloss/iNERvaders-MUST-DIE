using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Controller : MonoBehaviour
{
    public float sensitivity = 1;
    [Space]
    public float maximum_clamp;
    float xRotation = 0;

    float xMouse, yMouse;
    [Tooltip("For Horizontal rotation")] public Transform playerBody;


    void Start()
    {
        if (playerBody == null)
        {
            playerBody = GetComponentInParent<Transform>();
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Fetch_Mouse_Axis();
        Camera_Rotation();
    }

    private void Fetch_Mouse_Axis()
    {
        xMouse = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -maximum_clamp, maximum_clamp);
    }

    private void Camera_Rotation()
    {
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * xMouse);
    }
}
