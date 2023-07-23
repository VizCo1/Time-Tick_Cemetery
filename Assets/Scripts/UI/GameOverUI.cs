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

    private void LevelGameManager_OnStateChanged()
    {
        if (LevelGameManager.Instance.IsGameOver())
        {
            Show();

            _pickedUpKeysText.text = LevelGameManager.Instance.GetNumberOfKeys().ToString();

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
