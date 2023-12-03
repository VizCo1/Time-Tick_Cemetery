using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        clip.AddEvent(animationEvent);
    }
}
