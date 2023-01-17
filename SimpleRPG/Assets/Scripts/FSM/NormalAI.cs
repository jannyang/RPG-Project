using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NormalAI : BaseAI
{
    protected override void ProcessIdle()
    {
        base.ProcessIdle();
    }

    protected override IEnumerator Idle()
    {
        Debug.Log("Idle Entry");

        yield return new WaitForSeconds(3f);

        Vector3 pos = Vector3.zero;
        while (pos == Vector3.zero)
        {
            Vector3 dir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            Vector3 randomPosition = SelfTransform.position + dir * Random.Range(3.0f, 6.0f);
            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(randomPosition, out navMeshHit, 1.0f, NavMesh.AllAreas))
                    pos= randomPosition;
        }
        AddNextAI(eStateType.STATE_WALK, null, pos);

        yield return StartCoroutine(base.Idle());
    }

    protected override IEnumerator Attack()
    {
        yield return StartCoroutine(base.Attack());
    }

    protected override IEnumerator Move()
    {
        Debug.Log("Move Entry");
        if(MovePosition != Vector3.zero)
        {
            SetMove(MovePosition);

            if (Vector3.Distance(SelfTransform.position, MovePosition) < 1f)
            {
                Stop();
                AddNextAI(eStateType.STATE_IDLE);
            }
        }

        yield return StartCoroutine(base.Move());
    }

    protected override IEnumerator Die()
    {
        yield return StartCoroutine(base.Die());
    }

}
