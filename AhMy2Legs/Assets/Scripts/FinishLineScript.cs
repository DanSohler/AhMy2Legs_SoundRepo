using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public TimerScript instance;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instance.timerActive = false;
            FindObjectOfType<AudioManagerScript>().StopPlaying("bgm_main_theme");
            FindObjectOfType<AudioManagerScript>().Play("sfx_finish");
        }
    }
}
