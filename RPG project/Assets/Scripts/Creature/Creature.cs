using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

#region REQUIRE COMPONENTS
[RequireComponent(typeof(MovementByVelocityEvent))]
[RequireComponent(typeof(MovementByVelocity))]
[RequireComponent(typeof(MovementToPositionEvent))]
[RequireComponent(typeof(MovementToPosition))]

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthEvent))]

[DisallowMultipleComponent]
#endregion REQUIRE COMPONENTS


public class Creature : MonoBehaviour
{
    [HideInInspector] public Health health;
    [HideInInspector] public HealthEvent healthEvent;
    [HideInInspector] public MovementByVelocityEvent movementByVelocityEvent;
    [HideInInspector] public MovementToPositionEvent movementToPositionEvent;

    StatusData statusData;

    //public int damage = 10;
    //public int maxHP = 10;
    //public int currentHP = 10;
    //public int armor = 5;

    //public bool isAlive = true;

    //public const int KNOCK_BACK = 1;

    //protected float immuneTime = 0.5f;
    //protected float lastImmune;

    protected virtual void Awake()
    {
        health = GetComponent<Health>();
        healthEvent = GetComponent<HealthEvent>();

        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
    }



    protected virtual void OnEnable()
    {
        healthEvent.OnHealthChanged += HealthEvent_OnHealthChanged;
    }

    protected virtual void OnDisable()
    {
        healthEvent.OnHealthChanged -= HealthEvent_OnHealthChanged;
    }

    /// <summary>
    /// Handle health changed event
    /// </summary>
    private void HealthEvent_OnHealthChanged(HealthEvent healthEvent, HealthEventArgs healthEventArgs)
    {
        // If player has died
        if (healthEventArgs.healthAmount <= 0f)
        {
            //destroyedEvent.CallDestroyedEvent(true, 0);
        }
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void MoveToTarget()
    {

    }

    protected virtual void ReceiveDamage()
    {
        //if (!isAlive)
        //    return;
        //if(Time.time > lastImmune + immuneTime)
        //{
        //    lastImmune = Time.time;
        //    //Debug.Log("Damaged");
        //    currentHP--;
        //}
        
        //if (currentHP <= 0)
        //{
        //    currentHP = 0;
        //    Death();
        //}
    }

 
    protected virtual void Death()
    {

    }
}
