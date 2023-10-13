using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _pickedUpKeysText;

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

            _pickedUpKeysText.text = LevelGameManager.Instance.GetNumberOfKeys().ToString();

            MusicManager.Instance.StopMusic();
            SoundManager.Instance.PlayGameOverSound();

            float timeToLoad = 5f;
            DOVirtual.DelayedCall(timeToLoad, () => Loader.Load(Loader.Scene.MainMenuScene));
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
