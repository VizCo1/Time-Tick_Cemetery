using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string TO_DASH = "ToDash";
    private const string TO_IDLE = "ToIdle";
    private const string TO_MOVE = "ToMove";
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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

        _animator.SetBool(TO_MOVE, false);
        _animator.SetTrigger(TO_IDLE);
    }

    private void GameInput_OnDashPerformed(object sender, System.EventArgs e)
    {
        if (!LevelGameManager.Instance.IsGamePlaying())
            return;

        _animator.SetTrigger(TO_DASH);
    }

    private void GameInput_OnMovePerformed(object sender, System.EventArgs e)
    {
        if (!LevelGameManager.Instance.IsGamePlaying())
            return;

        _animator.SetBool(TO_MOVE, true);
    }
}
