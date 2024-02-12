using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageSpell : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    private float searchRadius = 10f;

    private Transform target;

    void Start()
    {
        target = FindClosestEnemy().transform;
        if (target == null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    Enemy FindClosestEnemy()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        float closestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance && distanceToEnemy <= searchRadius)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
