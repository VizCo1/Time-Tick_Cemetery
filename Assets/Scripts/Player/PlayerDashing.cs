using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.ParticleSystem;

public class PlayerDashing : MonoBehaviour
{

    [SerializeField] private float _dashingPower = 24f;
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private ParticleSystem _particles;

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

    private void Start()
    {
        GameInput.Instance.OnDashPerformed += GameInput_OnDashAction; 
    }

    private void GameInput_OnDashAction(object sender, EventArgs e)
    {
        if (_canDash && !_isDashing)
            PlayDashSequence();
    }

    //private void Update()
    //{
    //    if (!LevelGameManager.Instance.IsGamePlaying())
    //        return;
    //}

    private void PlayDashSequence()
    {
        Sequence dashSequence = DOTween.Sequence();

        _canDash = false;
        PlayerAnimations.Instance.SetCanDash(false);
        float correctionTime = 0.1f;

        _playerMovement.canMove = false;

        dashSequence
            .Append(_rigidbody.DOMove(_fencheHole.GetStartingDashPosition(transform.position), correctionTime))
            .AppendCallback(() =>
            {
                StartingResetDash();

                SoundManager.Instance.PlayDashSound(transform.position, 1.2f);
                
                // Push
                Vector3 direction = _fencheHole.transform.position - _fencheHole.GetCloserStartingPoint(transform.position);
                _rigidbody.velocity = direction * _dashingPower;

                transform.forward = direction;
            })
            .SetDelay(correctionTime)
            .OnComplete(() => _playerMovement.canMove = true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FenceHole fencheHole))
        {
            _fencheHole = fencheHole;
            _canDash = true;
            DashUI.Instance.Show();
            PlayerAnimations.Instance.SetCanDash(_canDash);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FenceHole fencheHole))
        {
            PlayerAnimations.Instance.SetCanDash(false);
            EndingResetDash();    
            DashUI.Instance.Hide();
        }
    }

    private void StartingResetDash()
    {
        _particles.Play();
        _canDash = false;
        _isDashing = true;
        _capsuleCollider.isTrigger = true;
        _trailRenderer.emitting = true;
        _playerMovement.SetIsDashing(_isDashing);
    }

    private void EndingResetDash()
    {
        _canDash = false;
        _trailRenderer.emitting = false;
        _isDashing = false;
        _capsuleCollider.isTrigger = false;
        _rigidbody.velocity = Vector3.zero;
        _playerMovement.SetIsDashing(_isDashing);
    }
}
