using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DashUI : MonoBehaviour
{
    public static DashUI Instance { get; private set; }

    [SerializeField] private GameObject _dashKeyImage;
    [SerializeField] private GameObject _keyboardText;
    [SerializeField] private GameObject _gamepadText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InputDeviceChangeHandler.Instance.OnGamepad += InputDeviceChangeHandler_OnGamepad;
        InputDeviceChangeHandler.Instance.OnKeyboard += InputDeviceChangeHandler_OnKeyboard;
        Hide();
    }

    private void InputDeviceChangeHandler_OnKeyboard(object sender, System.EventArgs e)
    {
        _keyboardText.SetActive(true);
        _gamepadText.SetActive(false);
    }

    private void InputDeviceChangeHandler_OnGamepad(object sender, System.EventArgs e)
    {
        _gamepadText.SetActive(true);
        _keyboardText.SetActive(false);

    }

    public void Show()
    {
        _dashKeyImage.SetActive(true);
    }

    public void Hide()
    {
        _dashKeyImage?.SetActive(false);
    }
}
