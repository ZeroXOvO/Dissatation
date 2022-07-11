using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("Player"))
        {
            SceneManager.LoadScene("End_Level");
        }
    }


}
