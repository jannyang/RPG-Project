using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class MovementEvent : MonoBehaviour
{
    public event Action<MovementEvent, MovementArgs> onMovement;

    public void CallMovementEvent(Vector2 moveDirection, float moveSpeed)
    {
        onMovement?.Invoke(this, new MovementArgs()
        {
            moveDirection = moveDirection,
            moveSpeed = moveSpeed
        }) ;
    }
}

public class MovementArgs : EventArgs
{
    public Vector2 moveDirection;
    public float moveSpeed;
}