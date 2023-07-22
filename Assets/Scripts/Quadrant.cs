using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Quadrant : MonoBehaviour
{

    [SerializeField] private GameObject[] _variants;

    private int _currentVariantIndex = 0;
    private bool _canChange = true;

    private void Start()
    {
        ChangeCurrentVariant();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { TryChangeCurrentVariant(); }
    }

    public bool TryChangeCurrentVariant()
    {
        if (_canChange)
        {
            ChangeCurrentVariant();
            return true;
        }

        return false;
    }

    private void ChangeCurrentVariant()
    {
        int newIndex;

        do
        {
            newIndex = Random.Range(0, _variants.Length);
        }
        while (newIndex == _currentVariantIndex);
        
        _variants[_currentVariantIndex].SetActive(false);
        _currentVariantIndex = newIndex;
        _variants[_currentVariantIndex].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            _canChange = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            _canChange = true;
        }
    }

    /*private void OnDrawGizmos()
    {
        //BoxCollider boxCollider = GetComponent<BoxCollider>();
        //Gizmos.DrawWireCube(transform.position, boxCollider.size);
    }*/
}
