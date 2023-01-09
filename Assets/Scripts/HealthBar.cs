using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    float damage = 0;
    float tiempo;

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    PlayerMovement playerMovement;

    void Start()
    {
        slider.maxValue = slider.value = currentHealth = maxHealth;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        fill.color = gradient.Evaluate(1f);

    }

    void Update()
    {
        tiempo = Time.time;

        if (tiempo > 120)
        {
            damage = 0.01f;

        }
        else if (tiempo > 90)
        {
            damage = 0.008f;

        }
        else if (tiempo > 60)
        {
            damage = 0.006f;

        }
        else
        {
            damage = 0.004f;

        }

        TimeDamage(damage);
        CheckHealth();
    }

    private void TimeDamage(float damage)
    {
        currentHealth -= damage;

        CheckHealth();
    }

    public void AddHealth()
    {
        currentHealth += 5;

        CheckHealth();
    }

    public void CheckHealth()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (currentHealth <= 0)
            playerMovement.Die();

    }
}
