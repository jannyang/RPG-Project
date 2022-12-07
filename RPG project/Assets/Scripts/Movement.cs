using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Creature))]        // �� �� ������Ʈ �ʼ�����
public class Movement : MonoBehaviour
{
    // private field -> _*
    private Creature _owner;
    public Creature owner
    {
        get {
            if (!_owner)
                _owner = this.GetComponent<Creature>();

            return _owner; 
        }
        set { owner = value; }
    }

    public void Move(Vector3 targetPosition, Vector3 thisPosition, float speed)
    {
        Vector3 vDist = targetPosition - thisPosition;
        Vector3 vDir = vDist.normalized;
        float fDist = vDist.magnitude;
        if (fDist > speed * Time.deltaTime)
            owner.transform.position += vDir * speed * Time.deltaTime;
    }
}
