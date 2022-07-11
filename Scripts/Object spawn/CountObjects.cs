using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountObjects : MonoBehaviour
{
    public float Delay = 1f;
    // Update is called once per frame
    void Update()
    {
        if (ObjectsToCollect.objects == 0)
        {
            Invoke("Update", Delay);
            SceneManager.LoadScene("End_Level");
        }
    }
}
