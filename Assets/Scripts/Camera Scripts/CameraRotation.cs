using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraRotation : MonoBehaviour, ISimpleInputDraggable
{
    private Transform target;
    public float rotationSpeed = 1f;
    private Vector3 initialMousePosition;
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
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // Check if the mouse click is over a UI element
                // gameObject.GetComponent<>
                Debug.Log("yes");
                isRotation = false;
                return; 
            }
            else
            {
                initialMousePosition = Input.mousePosition;
                isRotation = true;
            }
            
                
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
