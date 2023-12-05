using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] private Transform _title1Transform;
    [SerializeField] private Transform _title2Transform;
    [SerializeField] private Transform _title1GoToTransform;
    [SerializeField] private Transform _title2GoToTransform;

    [Space]

    [Header("Buttons")]
    [SerializeField] private Button _levelSelectorButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Transform _buttonsTransform;
    [SerializeField] private Transform _buttonsGoToTransform;

    private void Awake()
    {
        _levelSelectorButton.onClick.AddListener(() => SceneManager.LoadScene(Loader.Scene.LevelSelectorScene.ToString()));
        _settingsButton.onClick.AddListener(() => SceneManager.LoadScene(Loader.Scene.SettingsScene.ToString()));
#if !UNITY_WEBGL
        _quitButton.onClick.AddListener(() => Application.Quit());
#else
        Destroy(_quitButton.gameObject);
#endif
    }

    private void Start()
    {
        Sequence startSequence = DOTween.Sequence();

        startSequence
            .Append(_title1Transform.DOMoveY(_title1GoToTransform.position.y, 0.5f).SetEase(Ease.InOutSine))
            .Append(_title2Transform.DOMoveY(_title2GoToTransform.position.y, 0.5f).SetEase(Ease.InOutSine))
            .Append(_buttonsTransform.DOMoveY(_buttonsGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine));
    }
}
