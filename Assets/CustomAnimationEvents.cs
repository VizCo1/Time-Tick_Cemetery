using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomAnimationEvents : MonoBehaviour
{
    [Header("Needs an object with a PlayerAnimationsEvents component attached")]

    [SerializeField] private UnityEvent[] _unityEvents;

    public void PlayEvent(int i)
    {
        _unityEvents[i]?.Invoke();
    }

}
