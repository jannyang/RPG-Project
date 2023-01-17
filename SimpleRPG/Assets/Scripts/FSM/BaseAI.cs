using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NextAI
{
    public eStateType StateType;
    public BaseObject TargetObject;
    public Vector3 Position;
}

public class BaseAI : BaseObject
{
    protected List<NextAI> listNextAI = new List<NextAI>();
    protected eStateType _CurrentStateType = eStateType.STATE_IDLE;
    public eStateType CurrentStateType
    {
        get { return _CurrentStateType; }
    }

    // 나만 쓸수 있다.
    private bool bUpdateAI = false;


    // 공격 모션의 종료 유무 확인 용도
    private bool bAttack = false;
    public bool IsAttack
    {
        get { return bAttack; }
        set { bAttack = value; }
    }

    // AI의 종료
    private bool bEnd = false;
    public bool IsEnd
    {
        get { return bEnd; }
        set { bEnd = value; }
    }

    protected Vector3 MovePosition = Vector3.zero;
    private Vector3 preMovePosition = Vector3.zero;

    private Animator _animator = null;
    public Animator entityAnimator
    {
        get
        {
            if (_animator == null)
                _animator =
                    SelfObject.GetComponentInChildren<Animator>();

            return _animator;
        }
    }

    private NavMeshAgent _navAgent = null;
    public NavMeshAgent entityNavAgent
    {
        get
        {
            if (_navAgent == null)
                _navAgent = SelfObject.GetComponent<NavMeshAgent>();

            return _navAgent;
        }
    }

    private void ChangeAnimation()
    {
        if (entityAnimator == null)
        {
            Debug.LogError(SelfObject.name
                            + " 에게 Animator가 없습니다,");
            return;
        }

        entityAnimator.SetInteger("State", (int)CurrentStateType);
        // entityAnimator.Play()
    }

    protected bool MoveCheck()
    {
        if (entityNavAgent.pathStatus ==
                            NavMeshPathStatus.PathComplete)
        {
            if (entityNavAgent.hasPath == false ||
                 entityNavAgent.pathPending == false)
            {
                return true;
            }
        }

        return false;
    }

    protected void SetMove(Vector3 position)
    {
        if (preMovePosition == position)
            return;

        preMovePosition = position;
        entityNavAgent.isStopped = false;
        entityNavAgent.SetDestination(position);
    }

    protected void Stop()
    {
        MovePosition = Vector3.zero;
        entityNavAgent.isStopped = true;
    }

    public virtual void AddNextAI(
        eStateType nextStateType,
        BaseObject targetObject = null,
        Vector3 position = new Vector3())
    {
        NextAI nextAI = new NextAI
        {
            StateType = nextStateType,
            TargetObject = targetObject,
            Position = position
        };

        listNextAI.Add(nextAI);
    }

    protected virtual void ProcessIdle()
    {
        _CurrentStateType = eStateType.STATE_IDLE;
        ChangeAnimation();
    }

    protected virtual void ProcessMove()
    {
        _CurrentStateType = eStateType.STATE_WALK;
        ChangeAnimation();
    }

    protected virtual void ProcessAttack()
    {
        _CurrentStateType = eStateType.STATE_ATTACK;
        ChangeAnimation();
    }

    protected virtual void ProcessDie()
    {
        _CurrentStateType = eStateType.STATE_DEAD;
        ChangeAnimation();
    }

    // 구동부
    protected virtual IEnumerator Idle()
    {
        bUpdateAI = false;
        yield break;
    }

    protected virtual IEnumerator Move()
    {
        bUpdateAI = false;
        yield break;
    }

    protected virtual IEnumerator Attack()
    {
        bUpdateAI = false;
        yield break;
    }

    protected virtual IEnumerator Die()
    {
        bUpdateAI = false;
        yield break;
    }

    void SetNextAI(NextAI nextAI)
    {
        if (nextAI.TargetObject != null)
        {
            // TODO :: target Setting
            // Target.ThrowEvent(ConstValue.EventKey_SetTarget, nextAI.TargetObject);
        }

        if (nextAI.Position != Vector3.zero)
        {
            MovePosition = nextAI.Position;
        }

        switch (nextAI.StateType)
        {
            case eStateType.STATE_IDLE:
                ProcessIdle();
                break;
            case eStateType.STATE_WALK:
                ProcessMove();
                break;
            case eStateType.STATE_ATTACK:
                if (nextAI.TargetObject != null)
                {   // 타겟 오브젝트 바라보기
                    SelfTransform.forward =
                        (nextAI.TargetObject.SelfTransform.position
                        - SelfTransform.position).normalized;
                }
                ProcessAttack();
                break;
            case eStateType.STATE_DEAD:
                ProcessDie();
                break;
        }
    }

    public void UpdateAI()
    {
        // 현재 구동중인 상태가 있다.
        if (bUpdateAI == true)
            return;

        if (listNextAI.Count > 0)
        {
            SetNextAI(listNextAI[0]);
            listNextAI.RemoveAt(0);
        }

        if (ObjectState == eBaseObjectState.State_Die)
        {
            listNextAI.Clear();
            ProcessDie();
        }

        bUpdateAI = true;

        switch (CurrentStateType)
        {
            case eStateType.STATE_IDLE:
                StartCoroutine("Idle");

                //Coroutine coroutine = StartCoroutine(Idle());
                //StopCoroutine(coroutine);

                //StartCoroutine("Idle");
                //StopCoroutine("Idle");
                break;
            case eStateType.STATE_WALK:
                StartCoroutine("Move");
                break;
            case eStateType.STATE_ATTACK:
                StartCoroutine("Attack");
                break;
            case eStateType.STATE_DEAD:
                StartCoroutine("Die");
                break;
        }
    }

    public void ClearAI()
    {
        // 전체 삭제
        listNextAI.Clear();
    }

    //eStateType saveState;
    //public bool Removepredicate(NextAI nextAI)
    //{
    //    return nextAI.StateType == saveState;
    //}

    public void ClearAI(eStateType stateType)
    {
        // #1 
        //for (int i = 0; i < listNextAI.Count; i++)
        //{
        //    if (listNextAI[i].StateType == stateType)
        //        listNextAI.Remove(listNextAI[i]);
        //}

        // #2
        //List<int> removeIndex = new List<int>();
        //for (int i = 0; i < listNextAI.Count; i++)
        //{
        //    if (listNextAI[i].StateType == stateType)
        //        removeIndex.Add(i);
        //}

        //for (int i = 0; i < removeIndex.Count; i++)
        //{
        //    listNextAI.RemoveAt(removeIndex[i]);
        //}

        // #3
        //saveState = stateType;
        //listNextAI.RemoveAll(Removepredicate);

        // #4 Lamda
        listNextAI.RemoveAll(
            (NextAI) => {
                return NextAI.StateType
                  == stateType;
            });

        // #4-2
        //listNextAI.RemoveAll(
        //    (NextAI) => NextAI.StateType == stateType );

    }
}
