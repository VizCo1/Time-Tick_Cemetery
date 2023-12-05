using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _pickedUpKeysText;
    [SerializeField] LoadingBarUI _loadingBarUI;

    private void Start()
    {
        LevelGameManager.Instance.OnStateChanged += LevelGameManager_OnStateChanged;

        Hide();
    }

    private void OnDestroy()
    {
        LevelGameManager.Instance.OnStateChanged -= LevelGameManager_OnStateChanged;
    }

    private void LevelGameManager_OnStateChanged()
    {
        if (LevelGameManager.Instance.IsGameOver())
        {
            Show();

            _pickedUpKeysText.SetText(LevelGameManager.Instance.GetNumberOfKeys().ToString());

            MusicManager.Instance.StopMusic();
            SoundsManager.Instance.PlayGameOverSound();

            Loader.SetTargetScene(Loader.Scene.LevelSelectorScene);
            _loadingBarUI.StartLoadingBar();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
