using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public float MinTime = 0.05f;
    public float MaxTime = 1.2f;
    //[SerializeField()] AudioSource audioSource;

    private float timer;
    private Light l;

    // Start is called before the first frame update
    void Start()
    {
        
        l = GetComponent<Light>();
        timer = Random.Range(MinTime, MaxTime);
        

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            l.enabled = !l.enabled;
            //audioSource.Play();
            timer = Random.Range(MinTime, MaxTime);
        }
    }
}
