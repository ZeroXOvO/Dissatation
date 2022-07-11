using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player 1").transform.position = GameObject.FindGameObjectWithTag("PlayerSpawnPoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
