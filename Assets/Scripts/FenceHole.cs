using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceHole : MonoBehaviour
{
    [SerializeField] private Transform _startingPoint01;
    [SerializeField] private Transform _startingPoint02;
    [SerializeField] private FacingDirection _facingDirection;

    [Serializable] private enum FacingDirection
    {
        Facing_X,
        Facing_Z,
    }

    public Vector3 GetCloserStartingPoint(Vector3 playerPosition)
    {
        float distanceStartingPoint01 = Vector3.Distance(playerPosition, _startingPoint01.position);

        float distanceStartingPoint02 = Vector3.Distance(playerPosition, _startingPoint02.position);

        if (distanceStartingPoint01 < distanceStartingPoint02)
        {
            return _startingPoint01.position;
        }
        else
        {
            return _startingPoint02.position;
        }
    }

    public Vector3 GetStartingDashPosition(Vector3 playerPosition)
    {
        float distanceStartingPoint01 = Vector3.Distance(playerPosition, _startingPoint01.position);

        float distanceStartingPoint02 = Vector3.Distance(playerPosition, _startingPoint02.position);

        float distanceFencePlayer = Vector3.Distance(playerPosition, transform.position);

        if (_facingDirection == FacingDirection.Facing_X)
        {
            // Correct player's Z position
            return new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
        }
        else
        {
            // Correct player's X position
            return new Vector3(transform.position.x, playerPosition.y, playerPosition.z);
        }

        /*if (distanceFencePlayer < distanceStartingPoint01 && distanceFencePlayer < distanceStartingPoint02)
        {
            if (_facingDirection == FacingDirection.Facing_X)
            {
                // Correct player's Z position
                return new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
            }
            else
            {
                // Correct player's X position
                return new Vector3(transform.position.x, playerPosition.y, playerPosition.z);
            }
        }
        else if (distanceStartingPoint01 < distanceStartingPoint02)
        {
            return _startingPoint01.position;
        }
        else
        {
            return _startingPoint02.position;
        }*/
    }
}
