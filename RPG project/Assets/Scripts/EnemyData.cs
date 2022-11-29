using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = int.MaxValue)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private string enemyName;
    public string EnemyName { get { return enemyName; } }

    [SerializeField]
    private int maxHp;
    public int MaxHp { get { return maxHp; } }

    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    [SerializeField]
    private int armor;
    public int Armor { get { return armor; } }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField]
    private int exp;
    public float Exp { get { return exp; } }
}
