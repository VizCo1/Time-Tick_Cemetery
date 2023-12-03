using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using DG.Tweening;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dashParticles;
    [SerializeField] private ParticleSystem _moveParticles;
    [SerializeField] private TrailRenderer _dashTrail;

    [SerializeField] private MMSimpleObjectPooler _mMSimpleObjectPooler;

    public static PlayerEffects Instance;

    private void Awake()
    {
        Instance = this;
        _mMSimpleObjectPooler.GameObjectToPool = _moveParticles.gameObject;
    }

    public void SetDashTrail(bool setter)
    {
        _dashTrail.emitting = setter;
    }

    public void PlayDashParticles()
    {
        _dashParticles.transform.position = new Vector3(transform.position.x, _dashParticles.transform.position.y, transform.position.z);
        _dashParticles.Play();
    }

    public void PlayMoveParticles()
    {
        GameObject moveParticleGO = _mMSimpleObjectPooler.GetPooledGameObject();
        moveParticleGO.SetActive(true);
        moveParticleGO.transform.position = new Vector3(transform.position.x, moveParticleGO.transform.position.y, transform.position.z);

        ParticleSystem moveParticleSystem =  moveParticleGO.GetComponent<ParticleSystem>();
        moveParticleSystem.Play();
    }
}
