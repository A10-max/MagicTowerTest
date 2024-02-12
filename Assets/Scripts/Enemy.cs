using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public EnemyData enemyData;
    private int currentHealth;
    private Transform tower;

    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
        SetEnemyAttributes();
    }

    void Update()
    {
        MoveTowardsTower();
    }

    void MoveTowardsTower()
    {
        transform.LookAt(tower);
        transform.Translate(Vector3.forward * GetMovementSpeed() * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            Tower tower = other.GetComponent<Tower>();
            tower.TakeDamage(enemyData.damage);
            Destroy(gameObject);
        }
    }

    void SetEnemyAttributes()
    {
        switch (enemyType)
        {
            case EnemyType.Default:
                GetComponentInChildren<Renderer>().material.color = Color.red;
                break;
            case EnemyType.Fast:
                GetComponentInChildren<Renderer>().material.color = Color.blue;
                break;
            case EnemyType.BigAndSlow:
                GetComponentInChildren<Renderer>().material.color = Color.green;
                break;
        }

        switch (enemyType)
        {
            case EnemyType.Default:
                currentHealth = enemyData.maxHealth;
                break;
            case EnemyType.Fast:
                currentHealth = enemyData.maxHealth / 2;
                break;
            case EnemyType.BigAndSlow:
                currentHealth = enemyData.maxHealth * 2;
                break;
        }
    }

    float GetMovementSpeed()
    {
        switch (enemyType)
        {
            case EnemyType.Default:
                return enemyData.movementSpeed;
            case EnemyType.Fast:
                return enemyData.movementSpeed;
            case EnemyType.BigAndSlow:
                return enemyData.movementSpeed;
            default:
                return enemyData.movementSpeed;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

public enum EnemyType
{
    Default,
    Fast,
    BigAndSlow
}
[Serializable]
public struct EnemyData
{
    public float movementSpeed;
    public int maxHealth;
    public int damage;
}
