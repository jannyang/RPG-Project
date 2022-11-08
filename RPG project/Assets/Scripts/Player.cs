using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public int attackRange = 1;
    private Animator playerAnimator;
    private bool isAlive = true;
    private GameObject monsterObject;

    protected override void Start()
    {
        base.Start();
        playerAnimator = GetComponent<Animator>();
        monsterObject = GameObject.FindGameObjectWithTag("Enemy");
    }
    protected override void ReceiveDamage(int damage)
    {
        if (!isAlive)
            return;
        base.ReceiveDamage(damage);
    }

    private void Update()
    {
        if (monsterObject)
        {
            MoveToTarget();

            if (Mathf.Abs(monsterObject.transform.position.x - gameObject.transform.position.x) < attackRange)
                Attack();
        }
    }

    private void MoveToTarget()
    {

    }

    private void Attack()
    {
        playerAnimator.SetBool("Attack", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
