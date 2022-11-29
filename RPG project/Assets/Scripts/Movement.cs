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

    public void Move(Vector3 dir, float speed)
    {
        owner.transform.position += dir * speed * Time.deltaTime;
    }
}
