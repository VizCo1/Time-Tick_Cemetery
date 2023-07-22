using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashSpotLight : MonoBehaviour
{

    [Header("Inner spot angle")]

    [SerializeField] float _minInnerSpotAngle = 80f;
    [SerializeField] float _maxInnerSpotAngle = 145f;
    [SerializeField] float _innerSpotAngleTweenDuration = 2f;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Start()
    {
        DOVirtual.Float(_minInnerSpotAngle, _maxInnerSpotAngle, _innerSpotAngleTweenDuration, (float value) => _light.innerSpotAngle = value)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
