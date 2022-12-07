using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAI : BaseAI
{

    private float minDistance;
    private float distance;
    private int targetIdx;

    protected override IEnumerator Idle()
    {

        float distance = 0f;

        // 내 공격범위 안에 있으면 공격
        // 아니면 이동
        GameObject targetObject = null;
        
        // 근거리 적 색적

        if (targetObject != null)
        {
            float attackRange = 1.2f;
            
            if (distance < attackRange)
            {
                // Stop();   // 이동중이었다면 멈춤
                AddNextAI(eStateType.Attack, targetObject);
            }
            else
            {
                AddNextAI(eStateType.Move);
            }
        }

        yield return StartCoroutine(base.Idle());
    }

    protected override IEnumerator Move()
    {
        float distance = 0f;
        GameObject targetObject = null;

        if (targetObject != null)
        {
            float attackRange = 1f;

            if (distance < attackRange)
            {
                // Stop();
                AddNextAI(eStateType.Attack, targetObject);
            }
            else
            {
               
                // 타겟으로 이동
            }
        }

        yield return StartCoroutine(base.Move());
    }

    protected override IEnumerator Attack()
    {
        yield return new WaitForFixedUpdate();

        //while (IsAttack)
        //{
        //    if (SelfObject == null || SelfObject.activeSelf == false)
        //        yield break;

        //    yield return new WaitForFixedUpdate();
        //}


        AddNextAI(eStateType.Idle);
        yield return StartCoroutine(base.Attack());
    }

    protected override IEnumerator Die()
    {
        yield return StartCoroutine(base.Die());
    }
}
