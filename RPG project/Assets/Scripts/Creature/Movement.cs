using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private MovementEvent movementEvent;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        movementEvent = GetComponent<MovementEvent>();
    }

    private void OnEnable()
    {
        movementEvent.OnMovement += MovementEvent_OnMovement;    
    }

    private void OnDisable()
    {
        movementEvent.OnMovement -= MovementEvent_OnMovement;
    }

    private void MovementEvent_OnMovement(MovementEvent movementEvent, MovementArgs movementArgs)
    {
        MoveRigidbody(movementArgs.moveDirection, movementArgs.moveSpeed);
    }

    private void MoveRigidbody(Vector2 moveDirection, float moveSpeed)
    {
        rigidbody2D.velocity = moveDirection * moveSpeed;
    }
}
