using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MovementEvent))]

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
        movementEvent.onMovement += MovementEvent_OnMovement;
    }

    private void OnDisable()
    {
        movementEvent.onMovement -= MovementEvent_OnMovement;
    }

    private void MovementEvent_OnMovement(MovementEvent movementEvent, MovementArgs movementArgs)
    {
        MoveRigidBody(movementArgs.moveDirection, movementArgs.moveSpeed);
    }

    private void MoveRigidBody(Vector2 moveDirection, float moveSpeed)
    {
        rigidbody2D.velocity = moveDirection * moveSpeed;
    }



}
