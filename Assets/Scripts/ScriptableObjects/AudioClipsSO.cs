using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipsSO : ScriptableObject
{
    public AudioClip[] dashing;
    public AudioClip[] initialCountdown;
    public AudioClip[] keyPickedUp;
    public AudioClip gameover;
    public AudioClip clock;
}
