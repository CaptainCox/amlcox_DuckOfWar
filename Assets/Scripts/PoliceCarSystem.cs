using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarSystem : MonoBehaviour
{

    public GameObject enemyObject;
    public float spawnTime = 2f;
    public Transform[] policeSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, policeSpawnPoints.Length);

        Instantiate(enemyObject, policeSpawnPoints[spawnPointIndex].position, policeSpawnPoints[spawnPointIndex].rotation);
    }
}
