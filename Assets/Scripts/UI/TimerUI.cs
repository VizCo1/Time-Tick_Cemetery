using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{

    [SerializeField] private Image _timerImage;

    private void Update()
    {
        _timerImage.fillAmount = LevelGameManager.Instance.GetGamePlayingTimerNormalized();
    }
}
