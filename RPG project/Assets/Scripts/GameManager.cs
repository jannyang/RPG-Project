using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int playerLevel = 1;
    private int playerExp;
    private int playerGold;
    private int stage = 1;

    private void Awake()
    {
        if (GameManager._instance != null)
        {

        }
    }

    private void Start()
    {
        
    }

    private void StageMangager()
    {
        
    }
}
