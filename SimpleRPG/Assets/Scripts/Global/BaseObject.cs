using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    private BaseObject _target = null;

    public BaseObject Target    //property
    {
        get { return _target; }
        set { _target = value; }
    }

    private eBaseObjectState _objectState = eBaseObjectState.State_Normal;

    public eBaseObjectState ObjectState
    {
        get
        {
            if (Target == null)
                return _objectState;
            else
                return Target.ObjectState;
        }

        set
        {
            if (Target == null)
                _objectState = value;
            else
                Target.ObjectState = value;
        }
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

    // T 를 한정자(where) 컴포넌트로 제한을 뒀다
    public T SelfComponent<T>() where T : UnityEngine.Component
    {
        string objectName = string.Empty;
        string typeName = typeof(T).ToString();
        // typeof(GameObject) -> unityEngine.GameObject;
        T tempComponent = default(T);

        if (Target == null)
        {
            objectName = this.gameObject.name;

            tempComponent = this.GetComponent<T>();

            if (tempComponent == null)
            {
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

    //
    public Transform FindInChild(string findName)
    {
        return _FindInChild(findName, SelfTransform);
    }

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
    public virtual object GetData(string keyData, params object[] datas)
    {
        return null;
    }

    public virtual void ThrowEvent(string keyData, params object[] datas)
    {
    }
}