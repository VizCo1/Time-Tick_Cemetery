using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FogMaskBehaviour : MonoBehaviour
{

    [SerializeField] private Transform _followObject;
    [SerializeField] private float _initialOffsetZ = -0.6f;

    private void Update()
    {
        transform.position = new Vector3(_followObject.position.x, transform.position.y, _followObject.position.z + _initialOffsetZ);
    } 
}
