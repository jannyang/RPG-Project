using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MovementByVelocityEvent))]
[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class MovementByVelocity : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private MovementByVelocityEvent movementByVelocityEvent;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
    }

    private void OnEnable()
    {
        movementByVelocityEvent.OnMovementByVelocity += MovementEvent_OnMovement;    
    }

    private void OnDisable()
    {
        movementByVelocityEvent.OnMovementByVelocity -= MovementEvent_OnMovement;
    }

    private void MovementEvent_OnMovement(MovementByVelocityEvent movementEvent, MovementByVelocityArgs movementArgs)
    {
        MoveRigidbody(movementArgs.moveDirection, movementArgs.moveSpeed);
    }

    private void MoveRigidbody(Vector2 moveDirection, float moveSpeed)
    {
        rigidbody2d.velocity = moveDirection * moveSpeed;
    }
}
