using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    TestData testData;


    /*
     * out 
     * ref
     */

    public void GetNextReqExp(int grade, out int prevReqExp, out int nextReqExp)
    {
        LevelUpData next = testData.GetData(grade);
        LevelUpData prev = testData.GetData(grade - 1);

        prevReqExp = prev.upToEXP;
        nextReqExp = next.upToEXP;
    }

    public void GetNextReqExp(int grade, out LevelUpData prevReqExp, out LevelUpData nextReqExp)
    {
        nextReqExp = testData.GetData(grade);
        prevReqExp = testData.GetData(grade - 1);
    }

    void Func(int a, int b)
    {
        a++;
        b++;
    }

    void Func_ref(ref int a, ref int b)
    {
        a++;
        b++;
    }

    void Func_out(out int a, out int b)
    {
        // out 무조건 값을 할당한다
        a = 1; b= 2;

        a++;
        b++;
    }


    // Start is called before the first frame update
    void Start()
    {
        int a = 1; int b = 2;
        Func(a, b);

        Func_ref(ref a, ref b);
        Func_out(out a, out b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
