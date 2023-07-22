using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpAndDown : MonoBehaviour
{

    [SerializeField] private float _offsetY = 0.5f;
    [SerializeField] private float _duration = 1f;

    private void Start()
    {
        transform.DOMoveY(transform.position.y + _offsetY, _duration).SetLoops(-1, LoopType.Yoyo);
    }

}
