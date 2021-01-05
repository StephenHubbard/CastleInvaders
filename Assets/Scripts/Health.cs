﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    public int currentHealth;
    public Gradient gradient;
    public Image fill;

    public UnitConfig unitConfig;

    private void Start()
    {
        if (unitConfig == null) { return; }

        currentHealth = unitConfig.startingHealth;
        SetMaxHealth(unitConfig.startingHealth);
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        SetHealth(currentHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        if (slider == null) { return; }

        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}