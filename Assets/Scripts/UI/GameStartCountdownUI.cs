using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{

    private const string NUMBER_POPUP = "NumberPopup";

    [SerializeField] private TextMeshProUGUI _countdownText;

    private Animator _animator;
    private int _previousCountdownNumber;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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
        if (LevelGameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(LevelGameManager.Instance.GetCountdownToStartTimer());
        _countdownText.text = countdownNumber.ToString();

        if (_previousCountdownNumber != countdownNumber)
        { 
            _previousCountdownNumber = countdownNumber;
            _animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
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
