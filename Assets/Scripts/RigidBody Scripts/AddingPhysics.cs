using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingPhysics : MonoBehaviour
{
    // Start is called before the first frame update

    public float forceMagnitude = 1f;
    public float torqueMagnitude = 1f;
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * forceMagnitude);

        Rigidbody rb1 = GetComponent<Rigidbody>();
        rb1.AddTorque(Vector3.up * torqueMagnitude);

        Rigidbody rb2 = GetComponent<Rigidbody>();
        rb2.useGravity = true;
    }
}
