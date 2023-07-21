using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _maxMovementSpeed;

    private Rigidbody _rigidbody;
    private Vector2 _inputVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _inputVector = GetNormalizedInputVector();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

        Vector3 moveDir = new Vector3(_inputVector.x, 0f, _inputVector.y) * _movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + moveDir);

        if (_inputVector != Vector2.zero) 
        {
            float targetAngle = Mathf.Atan2(_inputVector.x, _inputVector.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);

            _rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }
    }

    private Vector2 GetNormalizedInputVector()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += +1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y += -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x += -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += +1;
        }

        return inputVector.normalized;
    }
}
