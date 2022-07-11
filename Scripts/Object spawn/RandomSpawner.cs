using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Reference to all spawnerObjects
    public GameObject[] spawnPoints;

    //Reference to spawn objects
    public GameObject gameObjectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //Find all Spawn points in the scene
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");

        //Call Spawn Function
        Spawn();
    }
    //Select One Of the Spawners Randomly 
    //Return the Selected Spawner
    GameObject SelectRandomSpawner()
    {
        GameObject selectedSpawner;
        selectedSpawner = spawnPoints[Random.Range(0, spawnPoints.Length)];

        return selectedSpawner;
    }

    //Spawn the Object
    void Spawn()
    {
        Instantiate(gameObjectsToSpawn, SelectRandomSpawner().transform.position, SelectRandomSpawner().transform.rotation);
    }
    
}
