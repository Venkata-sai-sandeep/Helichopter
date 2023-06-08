using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelechopterController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.E))
        {
            MoveDown();
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }

    }

    private void MoveUp()
    {
        rb.velocity = Vector3.up * moveSpeed;
    }

    private void MoveDown()
    {
        rb.velocity = Vector3.down * moveSpeed;
    }

    private void MoveForward()
    {
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1);
    }

    private void MoveBackward()
    {
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1);
    }

}
