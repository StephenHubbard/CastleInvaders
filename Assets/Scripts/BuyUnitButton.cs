using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BuyUnitButton : MonoBehaviour
{
    [SerializeField] UnitConfig unitConfig = null;
    [SerializeField] TMP_Text goldText = null;

    private SpawnUnitsHandler spawnUnitsHandler;

    public bool isUnlocked = false;

    private void Start()
    {
        spawnUnitsHandler = FindObjectOfType<SpawnUnitsHandler>();

        if (unitConfig != null)
        {
            goldText.text = unitConfig.goldCost.ToString();
        }

        CheckIfUnlocked();
    }

    public void CheckIfUnlocked()
    {
        if (isUnlocked == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void BuyUnit()
    {
        spawnUnitsHandler.SpawnFriendlyUnit(unitConfig);
    }

}
