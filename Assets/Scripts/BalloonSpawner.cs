using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject[] balloonPrefabs; // Array of balloon prefabs to instantiate
    public float spawnInterval = 5f;    // Time interval between spawns
    public float minYVelocity = -.8f;    // Minimum Y velocity
    public float maxYVelocity = .8f;     // Maximum Y velocity
    public float maxZVelocity = -.8f;          // Negative Z Maximum speed
    public float minZVelocity= -.2f;          // Negative Z Minimum speed

    // Bounds of the spawn rectangle
    public Vector2 xBounds = new Vector2(1.6f, 4.3f);
    public Vector2 yBounds = new Vector2(2.3f, 5.8f);

    private List<GameObject> weightedBalloonList;
    
    private void Start()
    {
        CreateWeightedBalloonList();
        StartCoroutine(SpawnBalloons());
    }

    private void CreateWeightedBalloonList()
    {
        weightedBalloonList = new List<GameObject>();

        foreach (GameObject balloonPrefab in balloonPrefabs)
        {
            Balloon balloon = balloonPrefab.GetComponent<Balloon>();
            if (balloon != null)
            {
                int weight = 15 / balloon.scoreValue; // Inverse proportional weight
                for (int i = 0; i < weight; i++)
                {
                    weightedBalloonList.Add(balloonPrefab);
                }
            }
        }
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

        // Randomly select a balloon prefab from the weighted list
        int randomIndex = Random.Range(0, weightedBalloonList.Count);
        GameObject balloonPrefab = weightedBalloonList[randomIndex];

        // Instantiate the balloon
        GameObject balloon = Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);

        // Set the balloon's initial velocity
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = new Vector3(0, Random.Range(minYVelocity, maxYVelocity), Random.Range(minZVelocity, maxZVelocity)).normalized;
            rb.velocity = direction;
        }
    }
}