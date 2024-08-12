using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    //ENCAPSULATION
    private readonly float spawnDelay = 2;
    private readonly float spawnInterval = 1.5f;
    private readonly float forceUp = 25.0f;
    private readonly float maxTorque = 2.0f;
    private readonly float maxForceSideways = 3.0f;
    private readonly float spawnRangeX = 25;
    private readonly float spawnPositionZ = -3.0f;
    private readonly float spawnPositionY = -18.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnInterval);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SpawnObject()
    {
        if (!gameManager.gameOver)
        {
            float randomSpawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);
            int randomObjectIndex = Random.Range(0, objectPrefabs.Length);
            Vector3 spawnPosition = new(randomSpawnPositionX, spawnPositionY, spawnPositionZ);
            GameObject spawnedObject = Instantiate(objectPrefabs[randomObjectIndex], spawnPosition, objectPrefabs[randomObjectIndex].transform.rotation);
            spawnedObject.GetComponent<Rigidbody>().AddForce(Vector3.up * forceUp, ForceMode.Impulse);
            spawnedObject.GetComponent<Rigidbody>().AddTorque(new(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque)), ForceMode.Impulse);
            if (randomSpawnPositionX > 0)
            {
                spawnedObject.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(-maxForceSideways, maxForceSideways), ForceMode.Impulse);
            }
            else
            {
                spawnedObject.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(-maxForceSideways, maxForceSideways), ForceMode.Impulse);
            }
        }
    }
}
