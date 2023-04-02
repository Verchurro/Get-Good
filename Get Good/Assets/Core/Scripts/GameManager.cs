using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource music;

    public bool startPlaying;

    public BeatScroller BS;

    public static GameManager instance;

    public int currentScore, scorePerNote = 100, currentMultiplier, multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText, multiText;


    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1; 
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

        multiplierTracker++;

        if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker) 
        {
            multiplierTracker = 0;
            currentMultiplier++;
        }

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
