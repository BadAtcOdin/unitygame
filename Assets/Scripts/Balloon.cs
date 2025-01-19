using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float speed = 0.5f; // Speed of the balloon
    protected Vector3 direction; // Direction of the balloon
    protected Rigidbody rb; // Reference to the Rigidbody component
    public int scoreValue = 1; // Default score value

    protected virtual void Start()
    {
        // Generate a random direction
        direction = new Vector3(0, Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

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

    protected virtual void FixedUpdate()
    {
        // Move the balloon in the direction
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Dart"))
        {
            // Update the score
            GameObject.Find("UIManager").GetComponent<UIManager>().UpdateScore(scoreValue);

            // Destroy the balloon
            Destroy(gameObject);
            Debug.Log("Balloon destroyed");
        }
        else
        {
            ContactPoint contact = collision.contacts[0];
            direction = Vector3.Reflect(direction, contact.normal);
            direction = direction.normalized;
        }
    }
}   