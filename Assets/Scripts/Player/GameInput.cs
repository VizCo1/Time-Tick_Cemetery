using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GameInput : MonoBehaviour
{
    private const string GAMEPAD = "Gamepad";
    private const string KEYBOARD = "Keyboard";

    public static GameInput Instance { get; private set; }

    public event EventHandler OnDashAction;
    public event EventHandler OnKeyboard;
    public event EventHandler OnGamepad;

    private PlayerInputActions _playerInputActions;
    private PlayerInput _playerInput;

    private void Awake()
    {
        Instance = this;

        _playerInput = GetComponent<PlayerInput>();

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Dash.performed += Dash_performed;
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

    private void Dash_performed(InputAction.CallbackContext obj)
    {
        //Debug.Log(obj.control.device.name);

        OnDashAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetNormalizedInputVector()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }
}
