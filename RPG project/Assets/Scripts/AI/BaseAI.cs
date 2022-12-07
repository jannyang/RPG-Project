using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eStateType
{
    Idle,
    Move,
    Attack,
    Die,
}


public class NextAIInfo
{
    public eStateType stateType;
    public GameObject targetObject;
    public Vector3 position;
}

public class BaseAI : MonoBehaviour
{
    protected GameObject owner;

    protected List<NextAIInfo> nextAIInfos = new List<NextAIInfo>();
    protected eStateType currentState = eStateType.Idle;
   
    

    public eStateType CurentState { get { return currentState; } }

    private bool isUpdateAI = false;

    private bool isEnd = false;
    public bool IsEnd
    {
        get { return isEnd; }
        set { isEnd = value; }
    }

    protected Vector3 movePosition = Vector3.zero;
    private Vector3 preMovePosition = Vector3.zero;

    private Animator animator = null;
    public Animator OwnerAnimator
    {
        get
        {
            if (!animator)
            {
                if (owner != null)
                    animator = owner.GetComponentInChildren<Animator>();
                    
                else
                    animator = this.GetComponentInChildren<Animator>();
                    
            }
            return animator;
        }
    }


    // NavMesh 사용시 동일하게 셋팅

    #region control-AI
    public void Setup(GameObject owner)
    {
        this.owner = owner;
    }

    public virtual void AddNextAI(NextAIInfo nextAIInfo)
    {
        AddNextAI(nextAIInfo.stateType, nextAIInfo.targetObject, nextAIInfo.position);
    }

    public virtual void AddNextAI(eStateType stateType, GameObject targetObject = null, Vector3 postion = new Vector3())
    {
        NextAIInfo nextAI = new NextAIInfo
        {
            stateType = stateType,
            targetObject = targetObject,
            position = postion
        };

        nextAIInfos.Add(nextAI);
    }

    void SetNextAI(NextAIInfo nextAI)
    {
        if(nextAI.targetObject != null)
        {
            // 타겟 설정
        }

        if(nextAI.position != Vector3.zero)
        {
            movePosition = nextAI.position;
        }


        switch (nextAI.stateType)
        {
            case eStateType.Idle:
                ProcessIdle();
                break;

            case eStateType.Move:
                ProcessMove();
                break;

            case eStateType.Attack:
                ProcessAttack();
                break;

            case eStateType.Die:
                ProcessDie();
                break;
        }
    }

    public void UpdateAI()
    {
        if(isUpdateAI == true)
        {
            return;
        }

        if(nextAIInfos.Count > 0)
        {
            SetNextAI(nextAIInfos[0]);
            nextAIInfos.RemoveAt(0);
        }

        isUpdateAI = true;

        switch(currentState)
        {
            case eStateType.Idle:
                StartCoroutine("Idle");

                // 코루틴 사용방법 소개

                // StartCoroutine("Idle");
                // StopCoroutine("Idle");

                //Coroutine coroutine = StartCoroutine(Idle());
                //StopCoroutine(coroutine);
                break;

            case eStateType.Move:
                StartCoroutine("Move");
                break;

            case eStateType.Attack:
                StartCoroutine("Attack");
                break;

            case eStateType.Die:
                StartCoroutine("Die");
                break;
        }

    }

    public void ClearAI()
    {
        // 전체 삭제
        nextAIInfos.Clear();
    }

    //eStateType saveState;
    //public bool Removepredicate(NextAIInfo nextAI)
    //{
    //    return nextAI.stateType == saveState;
    //}

    public void ClearAI(eStateType stateType)
    {
        // #1
        //for (int i = 0; i < nextAIInfos.Count; i++)
        //{
        //    if (nextAIInfos[i].stateType == stateType)
        //        nextAIInfos.Remove(nextAIInfos[i]);
        //}

        // #2
        //List<int> removeIndex = new List<int>();
        //for (int i = 0; i < nextAIInfos.Count; i++)
        //{
        //    if (nextAIInfos[i].stateType == stateType)
        //        removeIndex.Add(i);
        //}

        //for (int i = 0; i < removeIndex.Count; i++)
        //{
        //    nextAIInfos.RemoveAt(removeIndex[i]);
        //}

        // #3
        //saveState = stateType;
        //nextAIInfos.RemoveAll(Removepredicate);

        // #4 Lamda      -> 이름없는 함수 / () => {};
        nextAIInfos.RemoveAll(
            (NextAI) =>
            {
                return NextAI.stateType == stateType;
            });

        // #4-2
        //nextAIInfos.RemoveAll(
        //    (NextAI) => NextAI.StateType == stateType
        //    );
    }


    #endregion


    #region processing

    protected virtual void ProcessIdle()
    {
        currentState = eStateType.Idle;
        ChangeAnimation();
    }

    protected virtual void ProcessMove()
    {
        currentState = eStateType.Move;
        ChangeAnimation();
    }

    protected virtual void ProcessAttack()
    {
        currentState = eStateType.Attack;
        ChangeAnimation();
    }

    protected virtual void ProcessDie()
    {
        currentState = eStateType.Die;
        ChangeAnimation();
    }

    protected virtual IEnumerator Idle()
    {
        isUpdateAI = false;
        yield break;
    }

    protected virtual IEnumerator Move()
    {
        isUpdateAI = false;
        yield break;
    }

    protected virtual IEnumerator Attack()
    {
        isUpdateAI = false;
        yield break;
    }

    protected virtual IEnumerator Die()
    {
        isUpdateAI = false;
        yield break;
    }



    #endregion


    #region util_method

    private void ChangeAnimation()
    {
        if(!OwnerAnimator)
        {
            Debug.Log("animator is null");
            return;
        }

        OwnerAnimator.SetInteger("state", (int)currentState);
    }



    #endregion


}
