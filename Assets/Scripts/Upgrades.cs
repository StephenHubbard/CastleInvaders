using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private WinCondition winCondition;
    private GoldHandler goldHandler;

    [SerializeField] BuyUnitButton knight2BuyUnitButton;

    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        goldHandler = FindObjectOfType<GoldHandler>();
    }

    public void MoreGoldUpgrade()
    {
        goldHandler.startingWaveGold = goldHandler.startingWaveGold + 20;

        winCondition.ShowNewWaveText();
    }

    public void UnlockKnight2()
    {
        knight2BuyUnitButton.isUnlocked = true;

        knight2BuyUnitButton.CheckIfUnlocked();

        winCondition.ShowNewWaveText();

    }
}
