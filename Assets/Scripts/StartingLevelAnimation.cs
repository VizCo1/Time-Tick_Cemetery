using DG.Tweening;
using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLevelAnimation : MonoBehaviour
{

    private const string DOOR_OPEN = "Door_Open";

    [SerializeField] private Animator _animator;
    [SerializeField] private MMF_Player _MMF_Player;

    public bool AnimationHasFinished { get; set; } = false;

    public static StartingLevelAnimation Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        _MMF_Player.PlayFeedbacks();
    }
}
