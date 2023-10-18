using UnityEngine;

public class TrackerPlayer : MonoBehaviour
{
    private Renderer _renderer;

    [SerializeField] private CapsuleCollider _collider;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _renderer.sharedMaterial.SetVector("_SpherePos", _collider.transform.position);
        _renderer.sharedMaterial.SetFloat("_SphereRadius", _collider.radius);
    }
}