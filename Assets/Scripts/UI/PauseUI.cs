using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{

    [SerializeField] private Button _backToGameButton;
    [SerializeField] private Button _exitButton;

    public static PauseUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        _backToGameButton.onClick.AddListener(() => Hide());
        _exitButton.onClick.AddListener(() => { Time.timeScale = 1; Loader.Load(Loader.Scene.LevelSelectorScene); });
    }

    private void Start()
    {
        GameInputManager.Instance.OnPausePerformed += GameInputManager_OnPausePerformed;
        gameObject.SetActive(false);
    }

    private void GameInputManager_OnPausePerformed(object sender, System.EventArgs e)
    {
        if (LevelGameManager.Instance.IsGamePlaying()) 
        {
            Show();         
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        MobileUI.Instance.Hide();
        MusicManager.Instance.PauseMusic();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        if (SettingsManager.IsMobile == 1)
        {
            MobileUI.Instance.Show();
        }
        MusicManager.Instance.ResumeMusic();
    }
}
