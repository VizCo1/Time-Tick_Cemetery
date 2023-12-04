using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileUI : MonoBehaviour
{

    [SerializeField] private Button _dashButton;

    public static MobileUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (SettingsManager.IsMobile == 1)
        {
            LevelGameManager.Instance.OnStateChanged += LevelGameManager_OnStateChanged;
            _dashButton.onClick.AddListener(() => GameInputManager.Instance.Dash_Performed_Mobile());
            Debug.Log("IsMobile!");
        }

        Hide();
    }

    private void LevelGameManager_OnStateChanged()
    {
        if (LevelGameManager.Instance.IsGamePlaying())
        {
            Show();
            SetDashButtonInteractable(false);
        }
        else if (LevelGameManager.Instance.IsGameOver())
        {
            Hide();
        }
    }

    private void Show() => gameObject.SetActive(true);

    private void Hide() => gameObject.SetActive(false);

    public void SetDashButtonInteractable(bool setter) => _dashButton.interactable = setter;
}
