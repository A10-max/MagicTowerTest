using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpell : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    public float explosionRadius = 5f;
    public GameObject explosionEffect;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        //Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }
}