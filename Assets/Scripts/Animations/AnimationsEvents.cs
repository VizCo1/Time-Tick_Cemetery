using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    [Header("Needs an object with an AnimationEventsLauncher script")]

    [SerializeField] private CustomEventInAnimation[] _customEventsInAnimation;
    
    public void Start()
    {
        foreach (CustomEventInAnimation customEventInAnimation in _customEventsInAnimation) 
        {
            customEventInAnimation.ApplyEvent();
        }
    }
}