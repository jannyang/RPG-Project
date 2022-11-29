using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    public int damage = 10;
    public int maxHP = 10;
    public int currentHP = 10;
    public int armor = 5;

    private bool isAlive = true;

    public const int KNOCK_BACK = 1;

    private Vector3 knockBackDirection;
    private BoxCollider2D boxCollider;

    protected float immuneTime = 0.5f;
    protected float lastImmune;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void MoveToTarget()
    {

    }

    protected virtual void ReceiveDamage()
    {
        if (!isAlive)
            return;
        if(Time.time > lastImmune + immuneTime)
        {
            lastImmune = Time.time;
            Debug.Log("Damaged");
            currentHP--;
        }
        
        if (currentHP <= 0)
        {
            currentHP = 0;
            Death();
        }
    }

 
    protected virtual void Death()
    {

    }
}
