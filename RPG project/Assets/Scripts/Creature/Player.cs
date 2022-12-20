using System.Collections.Generic;
using UnityEngine;

public enum AI_State
{
    None,
    Normal
}

public enum Player_State
{
    Idle,
    Walk,
    Attack
}

public class Player : Creature
{
    public AI_State aiState;
    private BaseAI AI;

    public float attackRange = 1.5f;
    public float moveSpeed = 1.0f;

    public Animator playerAnimator;

    private NormalAI normalAi;

    protected List<Enemy> monsterList;

    private GameObject targetObject;
    private float minDistance;
    private float distance;

    private int targetIdx;

    //public bool bAlive = true;

    private MovementEvent _movementEvent;
    public MovementEvent MovementEvent
    { get { return _movementEvent; } }

    public IdleEvent idleEvent;

    private Weapon weapon;

    private void Awake()
    {
        _movementEvent = GetComponent<MovementEvent>();
        playerAnimator = GetComponentInChildren<Animator>();
        idleEvent = GetComponent<IdleEvent>();
        //weapon = GetComponentInChildren<Weapon>();

        monsterList = Enemy.GetAllEnemies();

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

    protected override void Start()
    {
        base.Start();
    }

    protected override void ReceiveDamage()
    {
        base.ReceiveDamage();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawCube(this.transform.position + Vector3.right, Vector2.one);
    //}

    private void Update()
    {
        // raycast
         Vector3 pos = this.transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.right);

        //if (hit)
        //{
        //    Debug.Log(hit.transform.name);
        //}

        //RaycastHit2D[] hit2Ds = Physics2D.BoxCastAll(pos + Vector3.right, Vector2.one, 0, Vector2.zero);

        //foreach(RaycastHit2D hit in hit2Ds)
        //{
        //    Debug.Log(hit.transform.name);
        //}
                
        //AI?.UpdateAI();
        /*
        if (isAlive)
        {
            if (monsterList.Count > 0)
            {
                targetObject = FindCloseTarget(monsterList);
                if (!targetObject)  // null
                    return;

                distance = CheckBetDistance(targetObject);

                if (distance >= attackRange)
                    MoveToTarget();
                else if (distance < attackRange)
                {
                    //Debug.Log("Attack");
                    Attack();
                }
            }
            else
            {
                playerAnimator.SetInteger("state", (int)Player_State.Idle);
                //GameManager.instance.stage += 1;
            }

        }
        */
    }

    private GameObject FindCloseTarget(List<Enemy> monsterList)
    {
        if (monsterList.Count <= 0)
            return null;

        for (int i = 0; i < monsterList.Count; i++)
        {
            distance = Vector3.Distance(gameObject.transform.position, monsterList[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetIdx = i;
            }
        }
        return monsterList[targetIdx].gameObject;
    }

    private float CheckBetDistance(GameObject targetObject)
    {
        float currentDistance = 0f;
        currentDistance = Vector3.Distance(gameObject.transform.position, targetObject.transform.position);
        return currentDistance;
    }

    protected override void MoveToTarget()
    {
        playerAnimator.SetInteger("state", (int)Player_State.Walk);

        FlipCheck();

        // movement.Move(targetObject.transform.position, gameObject.transform.position, moveSpeed);
    }

    protected override void Death()
    {
        base.Death();
    }

    private void FlipCheck()
    {
        float xDist = targetObject.transform.position.x - gameObject.transform.position.x;

        if (xDist < 0)
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        else
            gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void Attack()
    {
        playerAnimator.SetInteger("state", (int)Player_State.Attack);
        FlipCheck();
        weapon.SetCollider();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}