using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    [SerializeField] private bl_Joystick _joystick;

    public static GameInputManager Instance { get; private set; }

    public event EventHandler OnDashPerformed;
    public event EventHandler OnMovePerformed;
    public event EventHandler OnMoveCanceled;

    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        if (SettingsManager.IsMobile == 1)
        {
            _joystick.OnTouchDown += Move_Performed_Mobile;
            _joystick.OnTouchUp += Move_Canceled_Mobile;
        }
        else
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _playerInputActions.Player.Dash.performed += Dash_Performed;
            _playerInputActions.Player.Move.performed += Move_Performed;
            _playerInputActions.Player.Move.canceled += Move_Canceled;      
        }

        Instance = this;
    }

    private void OnDestroy()
    {
        if (SettingsManager.IsMobile == 1)
        {
            _joystick.OnTouchDown -= Move_Performed_Mobile;
            _joystick.OnTouchUp -= Move_Canceled_Mobile;
        }
        else
        {
            _playerInputActions.Player.Dash.performed -= Dash_Performed;
            _playerInputActions.Player.Move.performed -= Move_Performed;
            _playerInputActions.Player.Move.canceled -= Move_Canceled;

            _playerInputActions.Dispose();
        }
    }

    private void Move_Canceled(InputAction.CallbackContext obj)
    {
        OnMoveCanceled?.Invoke(this, EventArgs.Empty);
    }

    private void Move_Performed(InputAction.CallbackContext obj)
    {
        OnMovePerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Move_Canceled_Mobile()
    {
        OnMoveCanceled?.Invoke(this, EventArgs.Empty);
    }

    private void Move_Performed_Mobile()
    {
        OnMovePerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Dash_Performed(InputAction.CallbackContext obj)
    {
        OnDashPerformed?.Invoke(this, EventArgs.Empty);
    }
    
    public void Dash_Performed_Mobile()
    {
        OnDashPerformed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetNormalizedInputVector()
    {
        Vector2 inputVector = Vector2.zero;
        if (SettingsManager.IsMobile == 1 && _joystick.IsDown)
        {
            inputVector = (new Vector2(_joystick.Horizontal, _joystick.Vertical));
        }
        else if (SettingsManager.IsMobile == 0)
        {
            inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        }

        return inputVector.normalized;
    }
}
