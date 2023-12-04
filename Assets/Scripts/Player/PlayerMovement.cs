using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _maxMovementSpeed;

    private Rigidbody _rigidbody;
    private Vector2 _inputVector = Vector2.zero;
    private bool _isDashing = false;

    [HideInInspector] public bool canMove = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!LevelGameManager.Instance.IsGamePlaying())
        {
            _inputVector = Vector2.zero;
            return;
        }

        _inputVector = GameInputManager.Instance.GetNormalizedInputVector();
    }

    private void FixedUpdate()
    {
        if (!_isDashing)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        Vector3 moveDir = _movementSpeed * Time.deltaTime * new Vector3(_inputVector.x, 0f, _inputVector.y);
        _rigidbody.MovePosition(transform.position + moveDir);

        if (_inputVector != Vector2.zero) 
        {
            float targetAngle = Mathf.Atan2(_inputVector.x, _inputVector.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);

            _rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }
    }

    public void SetIsDashing(bool isDashing) => _isDashing = isDashing;
}
