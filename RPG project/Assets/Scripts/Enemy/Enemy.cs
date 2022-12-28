using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public int exp;
    public float moveSpeed = 0.5f;
    private static List<Enemy> enemies = new List<Enemy>();
    private GameObject playerObject;
    private Vector3 targetPosition;

    public static List<Enemy> GetAllEnemies()
    {
        return Enemy.enemies;
    }

    protected override void Awake()
    {
        base.Awake();
        Enemy.enemies.Add(this);
    }

    protected override void Start()
    {
        playerObject = GetComponent<GameObject>();
        
    }

    private void Update()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        targetPosition = playerObject.transform.position;
        // movement.Move(targetPosition, gameObject.transform.position, moveSpeed);
    }

    protected override void Death()
    {
        base.Death();
        gameObject.SetActive(false);
        Enemy.enemies.Remove(this);
    }
}
