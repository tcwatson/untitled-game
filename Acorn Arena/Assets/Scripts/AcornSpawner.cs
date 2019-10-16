using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime = 3f;
    public GameObject acorn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(acorn, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
