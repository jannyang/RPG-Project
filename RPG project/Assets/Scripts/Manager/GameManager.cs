using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int playerLevel = 1;
    public int playerExp;
    public int playerGold;
    public int stage = 1;

    private List<Enemy> monsterList;
    private void Awake()
    {
        if (GameManager._instance != null)
        {

        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        monsterList = Enemy.GetAllEnemies();
        if(monsterList == null)
        {
            Debug.Log("Stage Clear");
        }
    }
    private void StageMangager()
    {
        
    }
}
