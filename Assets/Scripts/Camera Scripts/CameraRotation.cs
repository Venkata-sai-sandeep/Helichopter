using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotation : MonoBehaviour
{
    private Transform target;
    public float rotationSpeed = 1f;
    private Vector3 initialMousePosition;
    private bool isRotation = true;

    public void Awake()
    {
        target = gameObject.transform.parent;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // Check if the mouse click is over a UI element
                isRotation = false;
                return; 
            }
            
            initialMousePosition = Input.mousePosition;
            isRotation = true;
                
        }

        if (Input.GetMouseButton(0) && isRotation)
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 delta = currentPosition - initialMousePosition;

            float rotationAmount = delta.x * rotationSpeed;
            transform.RotateAround(target.position, Vector3.up, rotationAmount);

            initialMousePosition = currentPosition;
        }
    }
}
