using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationScript : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed = 1f;

    private bool isRotating = false;
    private Vector3 lastMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            float rotationX = mouseDelta.x * rotationSpeed;
            float rotationY = mouseDelta.y * rotationSpeed;

            transform.RotateAround(target.position, Vector3.up, rotationX);
            transform.RotateAround(target.position, transform.right, -rotationY);

            lastMousePosition = Input.mousePosition;
        }
    }

}
