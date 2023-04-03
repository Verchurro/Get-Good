using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotions : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject defaultImg, clarImg, happyImg, greatImg;
    public GameObject missedImg, madImg;
    public GameManager manager;
    public float waiting;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        EmotionMissed();
        Great();
    }

    void EmotionMissed()
    {

        if (manager.missed == true)
        {

            defaultImg.SetActive(false);
            missedImg.SetActive(true);
            clarImg.SetActive(false);
            madImg.SetActive(true);
            StartCoroutine(ImgMissed());
        }
        if (manager.missed == false)
        {
            defaultImg.SetActive(true);
            missedImg.SetActive(false);
            clarImg.SetActive(true);
            madImg.SetActive(false);
        }
    
    }
    void Great()
    {

        if (manager.great == true)
        {

            defaultImg.SetActive(false);
            greatImg.SetActive(true);
            clarImg.SetActive(false);
            happyImg.SetActive(true);
            StartCoroutine(ImgGreat());
        }
        if (manager.great == false)
        {
            defaultImg.SetActive(true);
            greatImg.SetActive(false);
            clarImg.SetActive(true);
            happyImg.SetActive(false);
        }
    }
    public IEnumerator ImgMissed()
    {
        yield return new WaitForSeconds(waiting);
        manager.missed = false;
    }

    public IEnumerator ImgGreat()
    {
        yield return new WaitForSeconds(waiting);
        manager.great = false;
    }



}