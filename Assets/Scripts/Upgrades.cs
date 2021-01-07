using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private WinCondition winCondition;
    private GoldHandler goldHandler;
    private SpawnUnitsHandler spawnUnitsHandler;
    private SpellHandler spellHandler;

    [SerializeField] BuyUnitButton knight2BuyUnitButton;
    [SerializeField] BuyUnitButton knight3BuyUnitButton;
    [SerializeField] BuyUnitButton goldConjurorBuyUnitButton;
    [SerializeField] BuyUnitButton explosionSpellButton;
    [SerializeField] BuyUnitButton MageBuyUnitButton;
    [SerializeField] GameObject goldConjurorGameObject = null;
    [SerializeField] Health castleHealth = null;


    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        goldHandler = FindObjectOfType<GoldHandler>();
        spawnUnitsHandler = FindObjectOfType<SpawnUnitsHandler>();
        spellHandler = FindObjectOfType<SpellHandler>();
    }

    public void MoreGoldUpgrade()
    {
        goldHandler.startingWaveGold = goldHandler.startingWaveGold + 10;

        StartNewWave();

    }

    public void UnlockKnight2()
    {
        knight2BuyUnitButton.isUnlocked = true;

        knight2BuyUnitButton.CheckIfUnlocked();

        StartNewWave();

    }

    public void UnlockKnight3()
    {
        knight3BuyUnitButton.isUnlocked = true;

        knight3BuyUnitButton.CheckIfUnlocked();

        StartNewWave();
    }

    public void UnlockMage()
    {
        MageBuyUnitButton.isUnlocked = true;

        MageBuyUnitButton.CheckIfUnlocked();

        StartNewWave();
    }

    public void UnlockGoldConjuror()
    {
        goldConjurorBuyUnitButton.isUnlocked = true;

        goldConjurorBuyUnitButton.CheckIfUnlocked();

        goldConjurorGameObject.SetActive(true);

        StartNewWave();
    }

    public void UnlockExplosionSpell()
    {
        explosionSpellButton.isUnlocked = true;

        explosionSpellButton.CheckIfUnlocked();

        StartNewWave();
    }

    public void MoreMaxUnits()
    {
        spawnUnitsHandler.maxAmountOfFriendlyUnits += 2;

        StartNewWave();

    }

    public void RepairCastle()
    {
        castleHealth.currentHealth = castleHealth.castleMaxHealth;

        StartNewWave();
    }

    public void CastleMaxHealthUpgrade()
    {
        castleHealth.castleMaxHealth += 25;

        castleHealth.currentHealth += 25;

        castleHealth.SetMaxHealth(castleHealth.castleMaxHealth);

        StartNewWave();
    }

    

    private void StartNewWave()
    {
        winCondition.ShowNewWaveText();
    }
}
