using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyUnitButton : MonoBehaviour
{
    [SerializeField] UnitConfig unitConfig = null;
    [SerializeField] TMP_Text goldText = null;

    private void Start()
    {
        goldText.text = unitConfig.goldCost.ToString();
    }

}
