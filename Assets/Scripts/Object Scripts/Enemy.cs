using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    private Animator Running;
    private NavMeshAgent navMesh;
    private GameObject player;
    
    public GameObject jumpscareScren;
    public float speedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Running = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        navMesh.speed = speedEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination = player.transform.position;
        Running.SetBool("run", true);

        if (Vector3.Distance(transform.position, player.transform.position) < 0.9f) {
            navMesh.speed = 0;
            jumpscareScren.SetActive(true);
        }
    }
}
