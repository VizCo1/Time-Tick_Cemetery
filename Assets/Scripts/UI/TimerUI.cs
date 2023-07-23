using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{

    [SerializeField] private Image _timerImage;

    private float _soundTime = 0.75f;
    private float _timeToSubtract = 0.25f;

    private void Start()
    {
        _timerImage.fillAmount = 1;
    }

    private void Update()
    {
        if (LevelGameManager.Instance.IsGamePlaying())
        {
            _timerImage.fillAmount = LevelGameManager.Instance.GetGamePlayingTimerNormalized();

            if (_timerImage.fillAmount < _soundTime)
            {
                SoundManager.Instance.PlayClockSound();
                _soundTime -= _timeToSubtract;
            }
        }
    }
}
