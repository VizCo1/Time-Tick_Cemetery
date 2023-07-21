using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDashing : MonoBehaviour
{

    [SerializeField] private float _dashingPower = 24f;
    [SerializeField] private float _dashingCoolDown = 0.5f;

    private PlayerMovement _playerMovement;
    private bool _canDash = false;
    private bool _isDashing = false;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private FenceHole _fencheHole;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash && !_isDashing)
        {
            Dash();
        }
    }

    private void Dash()
    {
        PlayDashSequence();
    }

    private void PlayDashSequence()
    {
        Sequence dashSequence = DOTween.Sequence();

        float correctionTime = 0.1f;

        dashSequence
            .Append(_rigidbody.DOMove(_fencheHole.GetStartingDashPosition(transform.position), correctionTime))
            .AppendCallback(() =>
            {
                StartingResetDash();

                // Push
                Vector3 direction = _fencheHole.transform.position - _fencheHole.GetCloserStartingPoint(transform.position);
                _rigidbody.velocity = direction * _dashingPower;

                transform.forward = direction;
            });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FenceHole fencheHole))
        {
            _fencheHole = fencheHole;
            _canDash = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FenceHole fencheHole))
        {
            EndingResetDash();     
        }
    }

    private void StartingResetDash()
    {
        _canDash = false;
        _isDashing = true;
        _boxCollider.isTrigger = true;
        _playerMovement.SetIsDashing(_isDashing);
    }

    private void EndingResetDash()
    {
        _canDash = false;
        //_fencheHole = null;

        _isDashing = false;
        _boxCollider.isTrigger = false;
        _rigidbody.velocity = Vector3.zero;
        _playerMovement.SetIsDashing(_isDashing);
    }
}
