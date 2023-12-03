using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventsLauncher : MonoBehaviour
{
    [Header("Needs an object with an AnimationsEvents script")]

    [SerializeField] private UnityEvent[] _unityEvents;

    public void PlayEvent(int i)
    {
        _unityEvents[i]?.Invoke();
    }
}
