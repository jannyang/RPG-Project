using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class MovementEvent : MonoBehaviour
{
    public event Action<MovementEvent, MovementArgs> OnMovement;

    public void CallMovementEvent(Vector2 moveDirection, float moveSpeed)
    {
        OnMovement?.Invoke(this, new MovementArgs() { moveDirection = moveDirection, moveSpeed = moveSpeed });
    }
}

public class MovementArgs : EventArgs
{
    public Vector2 moveDirection;
    public float moveSpeed;
}

