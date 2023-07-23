using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{

    //private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipsSO _audioClipsSO;

    private float _volume = 1f;

    private void Awake()
    {
        Instance = this;

        //_volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
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
        PlaySound(_audioClipsSO.clock, Vector3.zero);
    }

    /*public void ChangeVolume()
    {
        _volume += .1f;
        if (_volume > 1f)
        {
            _volume = 0f;
        }

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, _volume);
        PlayerPrefs.Save();
    }

    public float GetVolume() => _volume;*/
}
