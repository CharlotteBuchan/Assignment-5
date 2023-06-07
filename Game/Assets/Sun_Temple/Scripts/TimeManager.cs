﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float TotalTime  = 600;
    public float TimeRemaining { get; private set; }

    public static Action<float> OnAdjustTime;
   

    private void Awake()
    {

        TimeRemaining = TotalTime;
    }


    void OnEnable()
    {
        OnAdjustTime += AdjustTime;
      
    }

    

    private void AdjustTime(float delta)
    {
        TimeRemaining += delta;
    }

    private void SetTime(int time, bool isFinite)
    {
        TotalTime = time;
        TimeRemaining = TotalTime;
    }

    void Update()
    {
  
            TimeRemaining -= Time.deltaTime;
            if (TimeRemaining <= 0)
            {
                TimeRemaining = 0;

            }

    }


}

