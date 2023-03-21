using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioSource music;
    public bool startPlaying;
    public BeatScroller BS;
    public static GameManager instance;


    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying= true;
                BS.hasStarted= true;

                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}