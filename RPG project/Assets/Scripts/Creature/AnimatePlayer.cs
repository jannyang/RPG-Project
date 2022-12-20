using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class AnimatePlayer : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        player.MovementEvent.OnMovement += MovementEvent_OnMovement;
        player.idleEvent.OnIdle += IdleEvent_OnIdle;
    }

    private void OnDisable()
    {
        player.MovementEvent.OnMovement -= MovementEvent_OnMovement;
        player.idleEvent.OnIdle -= IdleEvent_OnIdle;
    }

    private void IdleEvent_OnIdle(IdleEvent idleEvent)
    {
        SetIdleAnimationParameters();
    }

    private void MovementEvent_OnMovement(MovementEvent movementEvent, MovementArgs movementArgs)
    {
        SetMovementAnimationParameters();
    }

    private void SetIdleAnimationParameters()
    {
        player.playerAnimator.SetBool(Settings.isMoving, false);
        player.playerAnimator.SetBool(Settings.isIdle, true);
    }

    private void SetMovementAnimationParameters()
    {
        player.playerAnimator.SetBool(Settings.isMoving, true);
        player.playerAnimator.SetBool(Settings.isIdle, false);
    }
}
