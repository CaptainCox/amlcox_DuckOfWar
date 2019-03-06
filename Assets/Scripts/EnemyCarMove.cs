using UnityEngine;
using System.Collections;

public class EnemyCarMove : MonoBehaviour
{
    Transform playerObject;
    UnityEngine.AI.NavMeshAgent navmesh;


    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").transform;
        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        navmesh.SetDestination(playerObject.position);
    }
}