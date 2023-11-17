using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentTerrainVisualManager : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private MeshRenderer _wallRenderer;

    private Transform _wallTransform;

    private void Awake()
    {
        _wallTransform = _wallRenderer.GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 targetPos = _collider.transform.position;
        targetPos.y = _wallTransform.position.y;
        _wallRenderer.sharedMaterial.SetVector("_TargetPos", targetPos);
        _wallRenderer.sharedMaterial.SetFloat("_TargetRadius", _collider.radius);
    }
}
