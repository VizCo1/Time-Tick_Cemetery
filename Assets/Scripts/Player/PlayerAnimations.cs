using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string TO_DASH = "ToDash";
    private const string TO_IDLE = "ToIdle";
    private const string TO_SPRINT = "ToSprint";

    private bool _canDash = false;

    [SerializeField] private Animator _animator;

    public static PlayerAnimations Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnMovePerformed += GameInput_OnMovePerformed;
        GameInput.Instance.OnDashPerformed += GameInput_OnDashPerformed;
        GameInput.Instance.OnMoveCanceled += Instance_OnMoveCanceled;
    }

    private void Instance_OnMoveCanceled(object sender, System.EventArgs e)
    {
        if (!LevelGameManager.Instance.IsGamePlaying())
            return;

        _animator.SetBool(TO_SPRINT, false);
        _animator.SetTrigger(TO_IDLE);
    }

    private void GameInput_OnDashPerformed(object sender, System.EventArgs e)
    {
        if (!LevelGameManager.Instance.IsGamePlaying() || !_canDash)
            return;

        _animator.SetTrigger(TO_DASH);
        _canDash = false;
    }

    private void GameInput_OnMovePerformed(object sender, System.EventArgs e)
    {
        if (!LevelGameManager.Instance.IsGamePlaying())
            return;

        _animator.SetBool(TO_SPRINT, true);
    }

    public void SetCanDash(bool canDash)
    {
        _canDash = canDash;
    }
}
