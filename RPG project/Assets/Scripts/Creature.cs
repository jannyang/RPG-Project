using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    public string creatureName;

    public int attack = 10;
    public int hp = 10;
    public int currentHP = 10;
    public int armor = 5;
    public int level = 1;
    public int moveSpeed = 1;

    public const int KNOCK_BACK = 1;

    private Vector3 knockBackDirection;
    private BoxCollider2D boxCollider;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void ReceiveDamage(int damage)
    {
        currentHP -= damage;

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
