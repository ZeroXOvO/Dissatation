using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public  AudioSource Scream;
  //  public GameObject ThePlayer;
    public GameObject JumpCam;

     void OnTriggerEnter(Collider other)
    {
        
            Scream.Play();
            JumpCam.SetActive(true);
          //  ThePlayer.SetActive(false);

            StartCoroutine(Endjump());
        

    }
        IEnumerator Endjump()
        {
            yield return new WaitForSeconds(2.03f);
           // ThePlayer.SetActive(true);
            JumpCam.SetActive(false);
            GetComponent<Collider>().enabled = false;

        }
    

}
