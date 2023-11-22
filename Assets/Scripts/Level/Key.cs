using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private MMF_Player _MMFplayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _MMFplayer?.PlayFeedbacks(transform.position);
            transform.position = Vector3.zero;
            QuadrantManager.Instance.ChangeRandomVariant();
            LevelGameManager.Instance.KeyPickedUp();
            SoundManager.Instance.PlayKeySound(0.75f);
        }
    }
}
