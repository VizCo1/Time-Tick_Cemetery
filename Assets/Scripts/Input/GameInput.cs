using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnDashPerformed;
    public event EventHandler OnMovePerformed;
    public event EventHandler OnMoveCanceled;

    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        Instance = this;

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Dash.performed += Dash_Performed;
        _playerInputActions.Player.Move.performed += Move_Performed;
        _playerInputActions.Player.Move.canceled += Move_Canceled;
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Dash.performed -= Dash_Performed;
        _playerInputActions.Player.Move.performed -= Move_Performed;
        _playerInputActions.Player.Move.canceled -= Move_Canceled;

        _playerInputActions.Dispose();
    }

    private void Move_Canceled(InputAction.CallbackContext obj)
    {
        OnMoveCanceled?.Invoke(this, EventArgs.Empty);
    }

    private void Move_Performed(InputAction.CallbackContext obj)
    {
        OnMovePerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Dash_Performed(InputAction.CallbackContext obj)
    {
        OnDashPerformed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetNormalizedInputVector()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }
}
