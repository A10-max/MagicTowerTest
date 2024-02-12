using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject fireballPrefab;
    public GameObject barragePrefab;
    public GameObject gameOverScreen;

    [Header("Transforms")]
    public Transform firePoint;
    public Transform barrageFirePoint;

    [Header("Values")]
    public int maxHealth = 100;
    public int currentHealth;
    public float fireballCooldown = 2f;
    public float barrageCooldown = 5f;

    public Image healthImage;

    private float fireballTimer = 0f;
    private float barrageTimer = 0f;

    public void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (fireballTimer > 0)
        {
            fireballTimer -= Time.deltaTime;
        }

        if (barrageTimer > 0)
        {
            barrageTimer -= Time.deltaTime;
        }
    }

    public void CastFireballSpell()
    {
        if (fireballTimer <= 0)
        {
            Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            fireballTimer = fireballCooldown;
        }
    }

    public void CastBarrageSpell()
    {
        if (barrageTimer <= 0)
        {
            Instantiate(barragePrefab, barrageFirePoint.position, barrageFirePoint.rotation);
            barrageTimer = barrageCooldown;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void UpdateHealthUI()
    {
        float fillAmount = (float)currentHealth / maxHealth;
        healthImage.fillAmount = fillAmount;
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
