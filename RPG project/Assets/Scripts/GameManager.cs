using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Awake()
    {
        if (GameManager._instance != null)
        {

        }
    }
}
