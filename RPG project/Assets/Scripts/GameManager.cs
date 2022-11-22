using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int playerLevel = 1;
    private int playerExp;
    private int playerGold;
    private int stage = 1;

    private List<GameObject> monsterList;


    private void Awake()
    {
        if (GameManager._instance != null)
        {

        }
    }

    private void Start()
    {
        monsterList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    private void StageMangager()
    {
        if(monsterList.Count == 0)
        {
            stage++;
        }
    }
}
