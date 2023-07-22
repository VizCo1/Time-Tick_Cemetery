using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FogMaskBehaviour : MonoBehaviour
{

    [SerializeField] private float _minScaleValue;
    [SerializeField] private float _maxScaleValue;
    [SerializeField] private float _scalingduration = 1f; 
    [SerializeField] private float _initialOffsetZ = -0.6f;
    [SerializeField] private Transform _followObject;

    private void Start()
    {
        DOVirtual.Float(_minScaleValue, _maxScaleValue, _scalingduration, (float value) => transform.localScale = GetVectorFromFloat(value))
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        transform.position = new Vector3(_followObject.position.x, transform.position.y, _followObject.position.z + _initialOffsetZ);
    }

    private Vector3 GetVectorFromFloat(float value)
    {
        return new Vector3(value, value, value);
    }
}
