using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _particleSystem.transform.position = new Vector3(transform.position.x, _particleSystem.transform.position.y, transform.position.z);
            _particleSystem.Play();
            transform.position = Vector3.zero;
            QuadrantManager.Instance.ChangeRandomVariant();
            LevelGameManager.Instance.KeyPickedUp();
            SoundManager.Instance.PlayKeySound(0.75f);
        }
    }
}
