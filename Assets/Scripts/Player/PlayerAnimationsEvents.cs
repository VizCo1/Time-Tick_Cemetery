using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsEvents : MonoBehaviour
{
    [Header("Needs an object with an animator and CustomAnimationEvents components attached")]

    [SerializeField] private Animator _animator;
    [SerializeField] private CustomEventInAnimation[] _customEventsInAnimation;

    public void Start()
    {
        foreach (CustomEventInAnimation customEventInAnimation in _customEventsInAnimation) 
        {
            customEventInAnimation.ApplyEvent();
        }
    }
}

[Serializable]
public class CustomEventInAnimation
{

    public float time;
    public int eventIndex;
    public AnimationClip clip;

    public void ApplyEvent()
    {
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.time = time;
        animationEvent.intParameter = eventIndex;
        animationEvent.functionName = "PlayEvent";

        Debug.Log(animationEvent.functionName);

        clip.AddEvent(animationEvent);
    }
}
