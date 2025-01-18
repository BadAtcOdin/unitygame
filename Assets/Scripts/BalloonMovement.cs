using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float speed = 0.5f; // Speed of the balloon
    private Vector3 direction; // Direction of the balloon
    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Generate a random direction
        direction = new Vector3(0, Random.Range(-1f, 1f), Random.Range(-1f, 1f) ).normalized;

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("Rigidbody component is missing!");
        }
        else if (rb.isKinematic)
        {
            Debug.Log("Rigidbody component is kinematic!");
        }
    }

    void FixedUpdate()
    {
        // Move the balloon in the direction
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Collision detected with" +collision.gameObject.name );

        ContactPoint contact = collision.contacts[0];

        direction = Vector3.Reflect(direction, contact.normal);
        // direction.x = 0;
        direction = direction.normalized;

        

    }
}
