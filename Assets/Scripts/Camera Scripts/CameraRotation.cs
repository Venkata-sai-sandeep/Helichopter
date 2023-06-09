using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraRotation : MonoBehaviour
{
    private Transform target;
    public float rotationSpeed = 1f;
    private Vector3 initialTouchPosition;
    private bool isRotation = true;
    //public SteeringWheel steeringwheel;

    public void Awake()
    {
        target = gameObject.transform.parent;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIObject(Input.mousePosition))
            {
                // Check if the touch is over a UI element
                isRotation = false;
                return;
            }
            initialTouchPosition = Input.mousePosition;
            isRotation = true;
        }



        if (Input.GetMouseButton(0) && isRotation)
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 delta = currentPosition - initialTouchPosition;



            float rotationAmount = delta.x * rotationSpeed;
            transform.RotateAround(target.position, Vector3.up, rotationAmount);



            initialTouchPosition = currentPosition;
        }
    }
    bool IsPointerOverUIObject(Vector2 position)
    {
        EventSystem eventSystem = EventSystem.current;
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = position;
        System.Collections.Generic.List<RaycastResult> results = new System.Collections.Generic.List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
