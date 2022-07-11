using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareEvent : MonoBehaviour
{

    public Texture2D PlainTexuture;
    public Texture2D ScareTexture;
    public AudioClip Scaresound;
    public float scareTime = 3f;

    AudioSource Audio;
    bool showscare = false;


    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.mainTexture = ScareTexture;
            Audio.Stop();
            Audio.loop = false;
            Audio.clip = Scaresound;
            Audio.volume = 1f;
            Audio.Play();

            showscare = true;
        }
    }

    void Update()
    {
        if (showscare)
        {
            scareTime -= Time.deltaTime;
            if (scareTime <= 0)
            {
                GetComponent<Renderer>().material.mainTexture = PlainTexuture;
                Audio.Stop();
                showscare = false;
            }
        }
    }


}
