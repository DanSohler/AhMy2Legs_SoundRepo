using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]

public class TimerScript : MonoBehaviour
{
    public bool timerActive = false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;
    public BoxCollider finishLine;
    public bool timerAudioActive = false;

    public static TimerScript instance;

    float elapsed = 0f;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentTime = startMinutes * 60;
    }

    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                FindObjectOfType<AudioManagerScript>().Play("ui_timer_tick");
            }
            if (timerAudioActive == false)
            {
                FindObjectOfType<AudioManagerScript>().Play("ui_timer_start");
                timerAudioActive = true;
            }

        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
        FindObjectOfType<AudioManagerScript>().StopPlaying("bgm_main_theme");
    }
}
