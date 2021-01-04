using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldHandler : MonoBehaviour
{
    [SerializeField] TMP_Text goldText = null;

    public int currentGold = 500;

    void Start()
    {
        UpdateCurrentGold();
    }

    public void getGoldCost()
    {

    }

    public void UpdateCurrentGold()
    {
        goldText.text = $"Gold: {currentGold.ToString()}";
    }
}
