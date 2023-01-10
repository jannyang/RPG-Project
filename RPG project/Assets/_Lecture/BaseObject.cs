using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    private BaseObject _TargetComponent = null;
    public BaseObject Target    //property
    {
        get { return _TargetComponent; }
        set { _TargetComponent = value; }
    }
    public GameObject SelfObject
    {
        get
        {
            if (Target == null)
                return this.gameObject;
            else
                return Target.gameObject;
        }
    }

    public Transform SelfTransform
    {
        get
        {
            if (Target == null)
                return this.transform;
            else
                return Target.transform;
        }
    }

    public T SelfComponent<T>() where T : UnityEngine.Component
    {
        string objectName = string.Empty;
        string typeName = typeof(T).ToString();
        // typeof(GameObject) -> unityEngine.GameObject;
        T tempComponent = default(T);

        if (Target == null)
        {
            tempComponent = this.GetComponent<T>();

            if (tempComponent == null)
            {
                objectName = this.gameObject.name;
                Debug.LogError("ObjectName : " + objectName
                        + ", Missing Component : " + typeName
                        + " is null");

                tempComponent =
                     this.gameObject.AddComponent<T>();
            }
        }
        else
        {
            tempComponent = Target.SelfComponent<T>();
        }

        return tempComponent;
    }

    public Transform FindInChild(string findName)
    {
        return _FindInChild(findName, SelfTransform);
    }

    /*
     * Transform
     * A
     * - B
     * - - D
     * - - E
     * - C
     * - - F
     * 
     * transform.Find()
     * 
     */

    private Transform _FindInChild(string strName, Transform trans)
    {
        // 
        if (trans.name == strName)
            return trans;

        for (int i = 0; i < trans.childCount; i++)
        {
            Transform reTrans = _FindInChild(strName,
                                        trans.GetChild(i));

            if (reTrans) return reTrans;
        }

        return null;    // 자식을 다 뒤져봤지만 같은 이름을 찾을수 ...
    }

    // params -> 가변인자
    // printf("%d %d %d", 10, 20, 30)
    // int printf(const chat* format, ...)
    public virtual object GetData(string keyData, params object[] datas)
    {
        return null;
    }

    public virtual void ThrowEvent(string keyData, params object[] datas)
    {

    }
}
