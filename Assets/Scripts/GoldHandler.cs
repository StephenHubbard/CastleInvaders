using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldHandler : MonoBehaviour
{
    [SerializeField] TMP_Text goldText = null;

    public int startingWaveGold = 100;
    public int currentGold = 100;

    void Start()
    {

    }

    private void Update()
    {
        UpdateCurrentGold();
    }

    public void newWaveGold()
    {
        currentGold = startingWaveGold;
    }

    public void UpdateCurrentGold()
    {
        goldText.text = $"Gold: {currentGold.ToString()}";
    }
}
