using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AI_State
{
    None,
    Normal
}

public class Player : Creature
{
    public AI_State aiState;
    BaseAI AI;

    public int attackRange = 1;

    private Animator playerAnimator;
    

    private NormalAI normalAi;


    protected override void Start()
    {
        base.Start();
        playerAnimator = GetComponent<Animator>();
        

        switch (aiState)
        {
            case AI_State.None:
                AI = null;
                break;

            case AI_State.Normal:
                {
                    AI = gameObject.AddComponent<NormalAI>();
                }
                break;
        }
    }
    protected override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(damage);
    }

    private void Update()
    {
        AI?.UpdateAI();
    }

    protected override void MoveToTarget()
    {

    }

    protected override void Death()
    {
        base.Death();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
