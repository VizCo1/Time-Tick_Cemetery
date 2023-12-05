using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsInitializer : MonoBehaviour
{

    [SerializeField] private AudioMixer _audioMixer;

    private void Start()
    {
        SettingsManager.InitSettings(_audioMixer);
    }
}
