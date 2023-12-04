using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorUI : MonoBehaviour
{

    [Header("Title")]
    [SerializeField] private Transform _title1Transform;
    [SerializeField] private Transform _title1GoToTransform;

    [Space]

    [Header("Buttons")]
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Transform _buttonsTransform;
    [SerializeField] private Transform _buttonsGoToTransform;

    [Header("Stats")]
    [SerializeField] private Button _resetStatsButton;
    [SerializeField] private LevelStats[] _levelsStats;
    [SerializeField] private Transform _statsTransform;
    [SerializeField] private Transform _statsGoToTransform;


    private void Awake()
    {
        _level1Button.onClick.AddListener(() => Loader.Load(Loader.Scene.Level_1));
        _level2Button.onClick.AddListener(() => Loader.Load(Loader.Scene.Level_2));
        _resetStatsButton.onClick.AddListener(() => { SavingManager.ResetRecords(); UpdateLevelsStats(); _resetStatsButton.interactable = false; });

        _backToMainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(Loader.Scene.MainMenuScene.ToString()));
    }

    private void Start()
    {
        MusicManager.Instance.PlayMusic(MusicManager.Music.MenuMusic);
        UpdateLevelsStats();
        StartingAnimation();
    }

    private void UpdateLevelsStats()
    {
        foreach (LevelStats stats in _levelsStats)
        {
            stats.UpdateStats();
        }
    }

    private void StartingAnimation()
    {
        Sequence startSequence = DOTween.Sequence();

        startSequence
            .Append(_title1Transform.DOMoveY(_title1GoToTransform.position.y, 0.5f).SetEase(Ease.InOutSine))
            .Append(_buttonsTransform.DOMoveY(_buttonsGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine))
            .Join(_statsTransform.DOMoveY(_statsGoToTransform.position.y, 0.35f).SetEase(Ease.InOutSine));
    }

    private void OnDestroy()
    {
        DOTween.Clear();
    }
}
