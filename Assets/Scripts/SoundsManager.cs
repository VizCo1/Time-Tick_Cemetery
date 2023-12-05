using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance { get; private set; }

    [SerializeField] private AudioClipsSO _audioClipsSO;

    private float _volume = 1f;
    private AudioSource _clockAudioSource;

    private void Awake()
    {
        Instance = this;

        _clockAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _clockAudioSource.clip = _audioClipsSO.clock;
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * _volume);
    }

    public void PlayCountdownSound()
    {
        PlaySound(_audioClipsSO.initialCountdown, Vector3.zero);
    }

    public void PlayDashSound(Vector3 position, float volume = 1f)
    {
        PlaySound(_audioClipsSO.dashing, position, volume);
    }

    public void PlayKeySound(float volume = 1f)
    {
        PlaySound(_audioClipsSO.keyPickedUp, Vector3.zero, volume);
    }

    public void PlayGameOverSound()
    {
        PlaySound(_audioClipsSO.gameover, Vector3.zero);
    }

    public void PlayClockSound()
    {
        _clockAudioSource.Play();
    }
}
