using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAt : MonoBehaviour
{

    [SerializeField] private Transform _lookAtObject;
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        //transform.LookAt(new Vector3(_lookAtObject.position.x, transform.position.y, _lookAtObject.position.z), Vector3.up);

        Vector3 targetPosition = new Vector3(_lookAtObject.position.x, transform.position.y, _lookAtObject.position.z);

        var targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.deltaTime);
    }
}
