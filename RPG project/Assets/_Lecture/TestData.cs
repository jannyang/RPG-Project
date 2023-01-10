using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelUpData
{
    [SerializeField]
    public int upToEXP { get; private set; }

    
    [SerializeField]
    int atk;
    [SerializeField]
    int def;
}

[CreateAssetMenu(fileName = "New LevelData", menuName = "Scriptable Object/Level Data", order = 51)]
public class TestData : ScriptableObject
{

    [SerializeField]
    public List<LevelUpData> levelUpDatas;


    public LevelUpData GetData(int idx)
    {
        return levelUpDatas[idx];
    }
}
