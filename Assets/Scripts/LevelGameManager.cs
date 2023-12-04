using DG.Tweening;
using System;
using UnityEngine;

public class LevelGameManager : MonoBehaviour
{
    public static LevelGameManager Instance { get; private set; }

    public event Action OnStateChanged;

    private enum State
    {
        StartingAnimation,
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    [Header("Level configuration")]

    [SerializeField] private float _extraTime = 5f;
    [SerializeField] private float _minExtraTime = 0.5f;
    [SerializeField] private float _decreaseExtraTime = 0.5f;
    [SerializeField] private float _gamePlayingTimerMax = 30f;

    [Header("Level")]
    [SerializeField] private SavingManager.RecordKeys _levelKey;
    
    private State _state = State.WaitingToStart;
    private float _countdownToStartTimer = 3f;
    private float _waitingToStartTimer = 1f;
    private float _gamePlayingTimer;
    private int _numberOfKeys;

    private void Awake()
    {
        Instance = this;
        _state = State.StartingAnimation;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.StartingAnimation:
                if (StartingLevelAnimation.Instance.AnimationHasFinished)
                {
                    _state = State.WaitingToStart;
                    OnStateChanged?.Invoke();
                }
                break;
            case State.WaitingToStart:
                _waitingToStartTimer -= Time.deltaTime;
                if (_waitingToStartTimer < 0f)
                {
                    _state = State.CountdownToStart;
                    OnStateChanged?.Invoke();
                }
                break;
            case State.CountdownToStart:
                _countdownToStartTimer -= Time.deltaTime;
                if (_countdownToStartTimer < 0f)
                {
                    _state = State.GamePlaying;
                    _gamePlayingTimer = _gamePlayingTimerMax;
                    MusicManager.Instance.PlayMusic(MusicManager.Music.GameMusic);
                    OnStateChanged?.Invoke();
                }
                break;
            case State.GamePlaying:
                _gamePlayingTimer -= Time.deltaTime;
                if (_gamePlayingTimer < 0f)
                {
                    _state = State.GameOver;
                    if (_numberOfKeys > SavingManager.GetRecord(_levelKey))
                    {
                        SavingManager.SaveRecord(_levelKey, _numberOfKeys);
                    }
                    OnStateChanged?.Invoke();
                }
                break;
            case State.GameOver:
                break;
            
        }
    }

    public void KeyPickedUp()
    {
        _numberOfKeys++;

        if (_numberOfKeys % 5 == 0)
        {
            if (_extraTime >= _minExtraTime)
            {
                _extraTime -= _decreaseExtraTime;
            }
        }

        if (_gamePlayingTimer + _extraTime > _gamePlayingTimerMax)
        {
            _gamePlayingTimer = _gamePlayingTimerMax;
        }
        else
        {
            _gamePlayingTimer += _extraTime;
        }
    }

    public int GetNumberOfKeys() => _numberOfKeys;

    public float GetGamePlayingTimerNormalized() => _gamePlayingTimer / _gamePlayingTimerMax;

    public bool IsWaitingToStart() => _state == State.WaitingToStart;

    public bool IsGamePlaying() => _state == State.GamePlaying;

    public bool IsGameOver() => _state == State.GameOver;

    public bool IsCountdownToStartActive() => _state == State.CountdownToStart;

    public float GetCountdownToStartTimer() => _countdownToStartTimer;

    private void OnDestroy()
    {
        DOTween.Clear();
    }
}
