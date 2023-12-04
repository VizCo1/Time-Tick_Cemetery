using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurner : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [Header("Turn settings")]
    [SerializeField] private float _maxTurn = 25f;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _rotationSpeed = 2f;

    private Vector3 _initialEulerRotation;

    private void Awake()
    {
        _initialEulerRotation = transform.eulerAngles;
    }

    private void Start()
    {
        if (SettingsManager.CameraRotates == 0)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        float turnPercentage = Mathf.InverseLerp(0, _maxDistance, Mathf.Abs(_playerTransform.position.x));
        float targetAngles = transform.rotation.y + _maxTurn * (turnPercentage);

        if (_playerTransform.position.x < 0)
        {
            targetAngles = -targetAngles;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.Euler(_initialEulerRotation.x, targetAngles, _initialEulerRotation.z), 
            Time.deltaTime * _rotationSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(0, 1, 0), new Vector3(_maxDistance, 1, 0));
    }
}
