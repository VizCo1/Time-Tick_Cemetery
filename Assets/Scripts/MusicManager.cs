using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public enum Music
    {
        MenuMusic,
        GameMusic,
    }

    [SerializeField] private AudioClip[] _musicClips;

    public static MusicManager Instance { get; private set; }

    private AudioSource _music;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
            _music = GetComponent<AudioSource>();
            _music.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(Music music)
    {
        if (_music.clip != _musicClips[(int) music])
        {
            _music.Stop();
            _music.clip = _musicClips[(int) music];
            _music.Play();
        }
    }

    public void StopMusic()
    {
        _music.Stop();
    }

    public void PauseMusic()
    {
        _music.Pause();
    }

    public void ResumeMusic()
    {
        _music.UnPause();
    }

}
