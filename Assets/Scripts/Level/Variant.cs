using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variant : MonoBehaviour
{
    [SerializeField] private Transform[] _objectPositions;

    public Vector3 GetRandomObjectPosition() => _objectPositions[Random.Range(0, _objectPositions.Length)].position;
}
