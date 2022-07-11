using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class AI_Movement : MonoBehaviour
{
    private NavMeshAgent Enemy;
    GameObject Player;   // Making a Player val
    public bool IsEnemySeen;
    //public int Respawn;

    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");    //finding game onject with the player tag
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnemySeen)
        {
            Enemy.GetComponent<NavMeshAgent>().enabled = false;  // When Player looks at AI, AI movement disabled
        }
        else
        {
            GameObject.Find("Horror Girl").GetComponent<NavMeshAgent>().enabled = true;
            Enemy.transform.LookAt(Player.transform.position); //makes the AI constant look at player, if player is not looking at AI
            Enemy.SetDestination(Player.transform.position);   // When Player looks at AI, AI movement disabled, AI follows/teleports player
        }

    }
    void OnBecameVisible()
    {
        IsEnemySeen = true;     //if player looks at AI it moves
    }

    void OnBecameInvisible()
    {
        IsEnemySeen = false;   // if player looks away AI doesnt move
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game");

        }
    }
}
