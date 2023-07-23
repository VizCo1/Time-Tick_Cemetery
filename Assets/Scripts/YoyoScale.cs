using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScale : MonoBehaviour
{

    [SerializeField] private float _minScaleValue;
    [SerializeField] private float _maxScaleValue;
    [SerializeField] private float _scalingduration = 1f;

    private void Start()
    {
        DOVirtual.Float(_minScaleValue, _maxScaleValue, _scalingduration, (float value) => transform.localScale = GetVectorFromFloat(value))
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private Vector3 GetVectorFromFloat(float value)
    {
        return new Vector3(value, value, value);
    }

    private void OnDestroy()
    {
        DOTween.Clear();
    }
}
