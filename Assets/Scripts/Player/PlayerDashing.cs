using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDashing : MonoBehaviour
{

    [SerializeField] private float _dashingPower = 24f;

    private PlayerMovement _playerMovement;
    private bool _canDash = false;
    private bool _isDashing = false;
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private FenceHole _fencheHole;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
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
            DashUI.Instance.Show();
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FenceHole fencheHole))
        {
            EndingResetDash();    
            DashUI.Instance.Hide();
        }
    }

    private void StartingResetDash()
    {
        _canDash = false;
        _isDashing = true;
        _capsuleCollider.isTrigger = true;
        _playerMovement.SetIsDashing(_isDashing);
    }

    private void EndingResetDash()
    {
        _canDash = false;
        //_fencheHole = null;

        _isDashing = false;
        _capsuleCollider.isTrigger = false;
        _rigidbody.velocity = Vector3.zero;
        _playerMovement.SetIsDashing(_isDashing);
    }
}
