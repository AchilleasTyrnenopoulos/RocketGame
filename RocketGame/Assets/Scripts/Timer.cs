using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float currentTime = 0;
    [SerializeField]
    private double score = 0;

    private void Awake()
    {
    }

    private void OnDisable()
    {
        GameManager.instance.onPortalEnter -= ShowTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        //get high score for current scene from GameData

        GameManager.instance.onPortalEnter += ShowTime;        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.hasEnteredPortal)
            currentTime += Time.deltaTime;    
    }

    public void ShowTime()
    {
        CalculateScore();
        
        //TO DO check if score is lower than high score

        print($"Your time was {score}");
    }

    private void CalculateScore()
    {
        score = Math.Round(currentTime, 1);
    }

    
}
