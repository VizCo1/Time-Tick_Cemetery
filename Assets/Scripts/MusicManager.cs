using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    public static MusicManager Instance { get; private set; }

    private AudioSource _music;

    private void Awake()
    {
        Instance = this;
        _music = GetComponent<AudioSource>();
    }


    public void PlayMusic()
    {
        _music.Play();
    }

    public void StopMusic()
    {
        _music.Stop();
    }

}
