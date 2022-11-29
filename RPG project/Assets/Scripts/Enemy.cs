using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public int exp;

    private static List<Enemy> enemies = new List<Enemy>();

    public static List<Enemy> GetAllEnemies()
    {
        return Enemy.enemies;
    }

    private void Awake()
    {
        Enemy.enemies.Add(this);
    }

    protected override void Death()
    {
        base.Death();
        gameObject.SetActive(false);
        Enemy.enemies.Remove(this);
    }
}
