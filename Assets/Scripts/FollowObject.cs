using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _followObject;
    [SerializeField] private Vector3 _followOffset;

    private void Update()
    {
        transform.position = new Vector3(_followObject.position.x, transform.position.y, _followObject.position.z) + _followOffset;
    }
}
