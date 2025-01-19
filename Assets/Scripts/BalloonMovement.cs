using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float speed = 0.5f; // Speed of the balloon
    private Vector3 direction; // Direction of the balloon
    private Rigidbody rb; // Reference to the Rigidbody component
    private float score =0f ; // Score of the player

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
        
        Debug.Log("Collision detected with" + collision.gameObject.name );

        if (collision.gameObject.CompareTag("Dart")){ // If the balloon collides with a dart
            score = 1f; // Increase the score by 1
            //Destroy the balloon
            Destroy(gameObject);
            Debug.Log("Balloon destroyed");
            // Update the score
            GameObject.Find("UIManager").GetComponent<UIManager>().UpdateScore(score);
        }
        else { // If the balloon collides with a another object 
               // Reflect the direction of the balloon            
            ContactPoint contact = collision.contacts[0];

            direction = Vector3.Reflect(direction, contact.normal);

            direction = direction.normalized;

        }
        
        

    }
}
