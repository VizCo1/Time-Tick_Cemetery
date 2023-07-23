using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipsSO : ScriptableObject
{
    public AudioClip[] keyPickedUp;
    public AudioClip[] dash;
    public AudioClip[] footstep;
    public AudioClip[] gameover;
    public AudioClip[] clock;
    public AudioClip[] countdown;
}
