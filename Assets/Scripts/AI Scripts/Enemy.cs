// This script is used to controller the enemy actions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Require the NavMeshAgent component to be attached to this GameObject.
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    private Animator Running;
    private NavMeshAgent navMesh;
    private GameObject player;
    
    public static Enemy instance;
    
    [Space(5)]
    [Header("Canvas's GameObject")]
    public GameObject screen;
    
    [Space(7)]
    [Range(1, 4)]
    [Space(5)]
    public float speedEnemy;

    // This function set the instance of this script [Singleton Mode].
    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Running = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.speed = speedEnemy;
        
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        JumpScare();
    }

    // Function that triggers the jump scare activating canvas UI on the right moment.
    public void JumpScare() {
        if (Vector3.Distance(transform.position, player.transform.position) < 0.9f) {
            navMesh.speed = 0;
            screen.SetActive(true);
        }
    }

    // Function that starts the enemy's movement towards the player.
    public void Run() {
        navMesh.destination = player.transform.position;
        Running.SetBool("run", true);
    }
}
