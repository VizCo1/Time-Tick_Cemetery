using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputDeviceChangeHandler : MonoBehaviour
{
    private const string GAMEPAD = "Gamepad";
    private const string KEYBOARD = "Keyboard";

    public static InputDeviceChangeHandler Instance;

    private PlayerInput _playerInput;

    public event EventHandler OnKeyboard;
    public event EventHandler OnGamepad;

    private void Awake()
    {
        Instance = this;
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        InputUser.onChange += InputUser_OnChange;
    }

    private void InputUser_OnChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            switch (_playerInput.currentControlScheme)
            {
                case KEYBOARD:
                    OnKeyboard?.Invoke(this, EventArgs.Empty);
                    break;
                case GAMEPAD:
                    OnGamepad?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }

    }

}
