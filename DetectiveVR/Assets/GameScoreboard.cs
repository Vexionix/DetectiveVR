using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System;

public class GameScoreboard : MonoBehaviour
{
    private DateTime lastUpdate = DateTime.MinValue;
    private readonly TimeSpan updateInterval = TimeSpan.FromSeconds(2);
    public GameObject scoreboard;
    public TMP_Text scoreText;
    private int score = -1;

    
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((DateTime.Now - lastUpdate) >= updateInterval)
        {
            lastUpdate = DateTime.Now;
            score++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
