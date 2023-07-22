using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            transform.position = Vector3.zero;
            QuadrantManager.Instance.ChangeRandomVariant();
        }
    }
}
