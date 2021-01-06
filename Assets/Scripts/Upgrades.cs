using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private WinCondition winCondition;
    private GoldHandler goldHandler;
    private SpawnUnitsHandler spawnUnitsHandler;

    [SerializeField] BuyUnitButton knight2BuyUnitButton;
    [SerializeField] BuyUnitButton goldConjurorBuyUnitButton;
    [SerializeField] GameObject goldConjurorGameObject = null;


    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        goldHandler = FindObjectOfType<GoldHandler>();
        spawnUnitsHandler = FindObjectOfType<SpawnUnitsHandler>();
    }

    public void MoreGoldUpgrade()
    {
        goldHandler.startingWaveGold = goldHandler.startingWaveGold + 10;

        winCondition.ShowNewWaveText();
    }

    public void UnlockKnight2()
    {
        knight2BuyUnitButton.isUnlocked = true;

        knight2BuyUnitButton.CheckIfUnlocked();

        winCondition.ShowNewWaveText();
    }

    public void UnlockGoldConjuror()
    {
        goldConjurorBuyUnitButton.isUnlocked = true;

        goldConjurorBuyUnitButton.CheckIfUnlocked();

        goldConjurorGameObject.SetActive(true);

        winCondition.ShowNewWaveText();
    }

    public void MoreMaxUnits()
    {
        spawnUnitsHandler.maxAmountOfFriendlyUnits += 2;

        winCondition.ShowNewWaveText();
    }
}
