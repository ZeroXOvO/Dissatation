using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToCollect : MonoBehaviour
{
    public static int objects = 0;

    // initialization
    private void Awake()
    {
        objects++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("Player"))
            objects--;
        gameObject.SetActive(false);
    }
}
