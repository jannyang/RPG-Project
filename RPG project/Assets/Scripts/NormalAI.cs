using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAI : BaseAI
{
    protected List<GameObject> monsterList;

    public float moveSpeed = 0.1f;

    private float minDistance;
    private float distance;
    private int targetIdx;

    protected override IEnumerator Idle()
    {
        monsterList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        GameObject targetObject = FindCloseTarget(monsterList);

        float distance = 0f;
        distance = Vector3.Distance(gameObject.transform.position, targetObject.transform.position);
        // 내 공격범위 안에 있으면 공격
        // 아니면 이동
        
        
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
        monsterList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        GameObject targetObject = FindCloseTarget(monsterList);

       
        float distance = 0f;
        

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
                Vector3 vDist = monsterList[targetIdx].transform.position - gameObject.transform.position;
                Vector3 vDir = vDist.normalized;
                float fDist = vDist.magnitude;
                if (fDist > moveSpeed * Time.deltaTime)
                    transform.position += vDir * moveSpeed * Time.deltaTime;
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

    private GameObject FindCloseTarget(List<GameObject> monsterList)
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            distance = Vector3.Distance(gameObject.transform.position, monsterList[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetIdx = i;
            }
        }
        return monsterList[targetIdx];
    }
}
