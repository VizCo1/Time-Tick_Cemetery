using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class LevelGameManager : MonoBehaviour
{
    public static LevelGameManager Instance { get; private set; }

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State _state;
    private float _gamePlayingToStartTimerMax = 30f;
    private float _gamePlayingToStartTimer;

    private void Awake()
    {
        Instance = this;
        _gamePlayingToStartTimer = _gamePlayingToStartTimerMax;
        _state = State.GamePlaying;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.WaitingToStart:
                break;
            case State.GamePlaying:
                _gamePlayingToStartTimer -= Time.deltaTime;
                if (_gamePlayingToStartTimer < 0f)
                {
                    _state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;
        }
    }

    public float GetGamePlayingTimerNormalized() => 1 - (_gamePlayingToStartTimer / _gamePlayingToStartTimerMax);

}
