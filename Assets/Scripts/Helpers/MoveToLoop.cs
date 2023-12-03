using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveToLoop : MonoBehaviour
{
    [SerializeField] private Transform[] _goToTransform;

    private void Start()
    {
        Sequence moveSequence = DOTween.Sequence().Pause();

        foreach (Transform t in _goToTransform)
        {
            moveSequence.Append(transform.DOMove(t.position, Random.Range(1.5f, 2f)).SetEase(Ease.InOutSine));
            moveSequence.Join(transform.DOLookAt(t.position, 0.25f));
        }

        moveSequence.Play();
    }

}
