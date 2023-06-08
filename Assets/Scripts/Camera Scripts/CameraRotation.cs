using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Transform target;
    public float rotationSpeed = 1f;
    private Vector3 initialMousePosition;

    public void Awake()
    {
        target = gameObject.transform.parent;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 delta = currentPosition - initialMousePosition;

            float rotationAmount = delta.x * rotationSpeed;
            transform.RotateAround(target.position, Vector3.up, rotationAmount);

            initialMousePosition = currentPosition;
        }
    }
}
