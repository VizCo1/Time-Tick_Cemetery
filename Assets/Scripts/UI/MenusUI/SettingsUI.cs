using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] private Transform _title1Transform;
    [SerializeField] private Transform _title1GoToTransform;

    [Space]

    [Header("Buttons")]
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Transform _buttonsTransform;
    [SerializeField] private Transform _buttonsGoToTransform;

    [Header("Toggles")]
    [SerializeField] private Toggle[] _toggles;
    [SerializeField] private Transform _toggleTransform;
    [SerializeField] private Transform _toggleGoToTransform;

    [Header("Audio")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundsSlider;
    [SerializeField] private Button _soundsButton;
    [SerializeField] private Transform _audioTransform;
    [SerializeField] private Transform _slidersTransform;
    [SerializeField] private Transform _audioGoToTransform;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        InitToggles();
        InitSliders();

        _backToMainMenuButton.onClick.AddListener(() =>
        {
            SaveAllSetings();
            SceneManager.LoadScene(Loader.Scene.MainMenuScene.ToString());
        });

        _musicSlider.onValueChanged.AddListener((float sliderValue) => _audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20));
        _soundsSlider.onValueChanged.AddListener((float sliderValue) => _audioMixer.SetFloat("Sounds", Mathf.Log10(sliderValue) * 20));

        _soundsButton.onClick.AddListener(() => { _audioSource.Stop(); _audioSource.Play(); });
    }

    private void Start()
    {
        StartingAnimation();    
    }

    private void SaveAllSetings()
    {
        SavingManager.SaveSetting(SavingManager.SettingsKeys.IsMobile, _toggles[0].isOn);
        SavingManager.SaveSetting(SavingManager.SettingsKeys.CameraRotates, _toggles[1].isOn);
        SavingManager.SaveSetting(SavingManager.SettingsKeys.MusicVolume, _musicSlider.value);
        SavingManager.SaveSetting(SavingManager.SettingsKeys.SoundsVolume, _soundsSlider.value);
    }

    private void InitToggles()
    {
        int isMobile = SettingsManager.IsMobile;
        int cameraRotates = SettingsManager.CameraRotates;

        if (isMobile == 1)
        {
            _toggles[0].isOn = true;
        }
        else
        {
            _toggles[0].isOn = false;
        }

        if (cameraRotates == 1)
        {
            _toggles[1].isOn = true;
        }
        else
        {
            _toggles[1].isOn = false;
        }
    }

    private void InitSliders()
    {
        _musicSlider.value = SettingsManager.MusicVolume;
        _soundsSlider.value = SettingsManager.SFXVolume;
    }

    private void StartingAnimation()
    {
        Sequence startSequence = DOTween.Sequence();

        startSequence
            .Append(_title1Transform.DOMoveY(_title1GoToTransform.position.y, 0.5f).SetEase(Ease.InOutSine))
            .Append(_buttonsTransform.DOMoveY(_buttonsGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine))
            .Join(_toggleTransform.DOMoveY(_toggleGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine))
            .Join(_audioTransform.DOMoveY(_audioGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine))
            .Join(_slidersTransform.DOMoveY(_audioGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine));
    }
}
