using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Movement))]
public class Creature : MonoBehaviour
{
    public int damage = 10;
    public int maxHP = 10;
    public int currentHP = 10;
    public int armor = 5;

    public bool isAlive = true;

    public const int KNOCK_BACK = 1;


    protected float immuneTime = 0.5f;
    protected float lastImmune;

   

    protected virtual void Start()
    {
        
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
            //Debug.Log("Damaged");
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
