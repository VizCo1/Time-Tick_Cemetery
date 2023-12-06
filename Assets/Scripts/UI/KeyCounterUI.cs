using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _keyCounterText;
    [SerializeField] private MMF_Player _MmfPlayer;

    public static KeyCounterUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LevelGameManager.Instance.OnKeyPickedUp += LevelGameManager_OnKeyPickedUp;
        _keyCounterText.SetText("0");
    }

    private void LevelGameManager_OnKeyPickedUp(int number)
    {
        _keyCounterText.SetText(number.ToString());
        _MmfPlayer?.PlayFeedbacks();
    }


}
