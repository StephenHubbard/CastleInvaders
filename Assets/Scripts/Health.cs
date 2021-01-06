using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public Slider slider;
    public int currentHealth;
    public int castleMaxHealth;
    public Gradient gradient;
    public Image fill;
    public UnitConfig unitConfig;

    [SerializeField] TMP_Text castleHitPointsText = null;

    private WinCondition winCondition;

    private void Awake()
    {
        winCondition = FindObjectOfType<WinCondition>();

    }

    private void Start()
    {
        if (unitConfig == null) { return; }

        DetectIfCastle();

        currentHealth = unitConfig.startingHealth;

        SetMaxHealth(unitConfig.startingHealth);

        DetectIfEnemyHealthUpgrade();

    }

    private void DetectIfEnemyHealthUpgrade()
    {
        if (unitConfig.isEnemy)
        {
            int healthBonus;

            healthBonus = winCondition.currentWave / 5;

            SetMaxHealth(unitConfig.startingHealth + healthBonus);

            currentHealth = unitConfig.startingHealth + healthBonus;
        }
    }

    private void DetectIfCastle()
    {
        if (unitConfig.unitName == "Castle_main")
        {
            castleMaxHealth = currentHealth;
        }
    }

    private void Update()
    {
        Die();
        UpdateCastleHitPointsText();
        SetHealth(currentHealth);

    }

    private void UpdateCastleHitPointsText()
    {
        if (unitConfig.unitName != "Castle_main") { return; }
        castleHitPointsText.text = $"{currentHealth} / {castleMaxHealth}";
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            // detect if enemy unit
            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
