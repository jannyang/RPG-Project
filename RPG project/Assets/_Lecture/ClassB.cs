using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassB : BaseObject
{
    Rigidbody rd;
    // Start is called before the first frame update
    public void Init()
    {
        rd = SelfComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void update()
    {
        SelfTransform.position += Vector3.forward;
    }

    public override void ThrowEvent(string keyData, params object[] datas)
    {
        if (keyData == "attack target")
        {
            BaseObject bo = datas[0] as BaseObject;
            // BaseObject bo = (BaseObject)datas[0];

        }
        else
        {
            base.ThrowEvent(keyData, datas);
        }
    }
}
