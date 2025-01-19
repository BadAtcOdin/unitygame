using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShooter : MonoBehaviour
{
    public GameObject dartPrefab; // The dart prefab to instantiate
    public float minDartSpeed = 40f; // Minimum Speed of the dart
    public float maxDartSpeed = 60f; // Maximum Speed of the dart
    public float holdtime = 0f; // Time the mouse left button is held down
    private bool canShoot = true; // Prevent immediate shooting after resuming

    void Update()
    {
        // Prevent shooting while the game is paused or input is ignored
        if (PauseManager.isPaused || !canShoot) return;

        // Increment hold time while the fire button is held down
        if (Input.GetButton("Fire1")) // Left mouse button or Ctrl key
        {
            holdtime += Time.deltaTime;
        }

        // Shoot the dart when the fire button is released
        if (Input.GetButtonUp("Fire1"))
        {
            ShootDart();
            holdtime = 0f; // Reset the hold time
        }
    }

    void ShootDart()
    {
        // Perform a raycast from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint = ray.GetPoint(1000); // Default target point

        // Calculate the direction from the camera to the target point
        Vector3 direction = (targetPoint - transform.position).normalized;

        // Instantiate the dart at the camera's position and rotation
        GameObject dart = Instantiate(dartPrefab, transform.position, Quaternion.LookRotation(direction));

        // Get the Rigidbody component of the dart
        Rigidbody rb = dart.GetComponent<Rigidbody>();

        // Calculate the dart speed based on the hold time
        float dartSpeed = Mathf.Clamp(minDartSpeed + holdtime * (maxDartSpeed - minDartSpeed), minDartSpeed, maxDartSpeed);

        // Set the velocity of the dart
        if (rb != null)
        {
            rb.velocity = direction * dartSpeed;
        }
    }

    // Allow input after resuming the game
    public void AllowShooting()
    {
        StartCoroutine(EnableShootingAfterFrame());
    }

    private IEnumerator EnableShootingAfterFrame()
    {
        yield return null; // Wait for one frame to ignore held-down inputs
        canShoot = true;
    }

    // Prevent shooting immediately when the game is resumed
    public void BlockShooting()
    {
        canShoot = false;
    }
}
