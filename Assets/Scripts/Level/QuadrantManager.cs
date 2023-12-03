using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuadrantManager : MonoBehaviour
{
    
    [SerializeField] private Quadrant[] _quadrantArray;
    [SerializeField] private GameObject _key;

    public static QuadrantManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeAllVariants();
        ChangeRandomVariant();
    }

    private void ChangeAllVariants()
    {
        foreach (Quadrant quadrant in _quadrantArray)
        {
            quadrant.TryChangeCurrentVariant();
        }
    }

    public void ChangeRandomVariant()
    {
        _quadrantArray.Shuffle();

        foreach (Quadrant quadrant in _quadrantArray)
        {
            if (quadrant.TryChangeCurrentVariant())
            {
                MoveKeyToQuadrant(quadrant);
                break;
            }
        }
    }

    private void MoveKeyToQuadrant(Quadrant quadrant)
    {
        Vector3 availablePosition = quadrant.GetAvailablePositionInCurrentVariant();

        _key.transform.position = availablePosition;
    }
}
