using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource music;

    public bool startPlaying, missed = false, great = false;

    public BeatScroller BS;

    public static GameManager instance;

    public int currentScore, scorePerNote = 100, currentMultiplier, multiplierTracker, scorePerGoodNote = 125, scorePerPerfectnote = 150;
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
        missed= false;
        great = true;
        multiplierTracker++;

        if (currentMultiplier - 1 < multiplierThresholds.Length) 
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void Perfect()
    {
        currentScore += scorePerPerfectnote * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier= 1;
        multiplierTracker= 0;
        missed = true;
        great = false;
    }
}
