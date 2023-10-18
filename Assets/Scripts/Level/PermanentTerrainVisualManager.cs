using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentTerrainVisualManager : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] MeshRenderer _wallRenderer;

    private void Update()
    {
        _wallRenderer.sharedMaterial.SetVector("_SpherePos", _collider.transform.position);
        _wallRenderer.sharedMaterial.SetFloat("_SphereRadius", _collider.radius);
    }
}
