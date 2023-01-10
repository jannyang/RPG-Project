using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassA : BaseObject
{
    ClassB ai;
    BaseObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        ai = this.GetComponent<ClassB>();
        ai.Target = this;
        ai.Init();

        enemy.ThrowEvent("attack target", this);
    }

    // Update is called once per frame
    void Update()
    {
        ai.update();
    }
}
