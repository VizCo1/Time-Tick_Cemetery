using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        InitToggles();

        _backToMainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Loader.Scene.MainMenuScene.ToString());
            SavingManager.SaveSetting(SavingManager.SettingsKeys.IsMobile, _toggles[0].isOn);
            SavingManager.SaveSetting(SavingManager.SettingsKeys.CameraRotates, _toggles[1].isOn);
        });
    }

    private void Start()
    {
        StartingAnimation();    
    }

    private void InitToggles()
    {
        int isMobile = SavingManager.GetSetting(SavingManager.SettingsKeys.IsMobile);
        int cameraRotates = SavingManager.GetSetting(SavingManager.SettingsKeys.CameraRotates);

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

    private void StartingAnimation()
    {
        Sequence startSequence = DOTween.Sequence();

        startSequence
            .Append(_title1Transform.DOMoveY(_title1GoToTransform.position.y, 0.5f).SetEase(Ease.InOutSine))
            .Append(_buttonsTransform.DOMoveY(_buttonsGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine))
            .Join(_toggleTransform.DOMoveY(_toggleGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine));
    }
}
