using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;
    float spawnRangeX = 12;
    float spawnRangeZ = 18;
    float startDelay = 2;
    float spawnInterval = 1.5f;
    void Start()
    {
       InvokeRepeating("RandomSpawn", startDelay, spawnInterval);
  
    }

    void Update()
    {
        
    }

    
     void RandomSpawn()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }
    
}
  
 