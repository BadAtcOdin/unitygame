using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;    // The balloon prefab to instantiate
    public float spawnInterval = 5f;    // Time interval between spawns
    public float minYVelocity = -1f;    // Minimum Y velocity
    public float maxYVelocity = 1f;     // Maximum Y velocity
    public float zSpeed = -2f;          // Fixed negative Z speed

    // Bounds of the spawn rectangle
    public Vector2 xBounds = new Vector2(1.6f, 4.3f);
    public Vector2 yBounds = new Vector2(2.3f, 5.8f);

    private void Start()
    {
        StartCoroutine(SpawnBalloons());
    }

    private IEnumerator SpawnBalloons()
    {
        while (true)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBalloon()
    {
        // Generate a random position within the rectangle at Z = 6
        float xPosition = Random.Range(xBounds.x, xBounds.y);
        float yPosition = Random.Range(yBounds.x, yBounds.y);
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 6f);

        // Instantiate the balloon
        GameObject balloon = Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);

        // Set the balloon's initial velocity
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = new Vector3(0, Random.Range(minYVelocity, maxYVelocity), zSpeed).normalized;
            rb.velocity = direction;
        }
    }
}
