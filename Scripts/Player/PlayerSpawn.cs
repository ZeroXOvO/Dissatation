using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject SpawnLocation;
    GameObject Player;
    private Vector3 RespawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");  //find player

        SpawnLocation = GameObject.FindGameObjectWithTag("PlayerSpawn");  //get spawn location

        RespawnLocation = Player.transform.position;  //respawn character

        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        GameObject.Instantiate(Player, SpawnLocation.transform.position, Quaternion.identity);
    }
}
