using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tips : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] private string[] tipsArray;

    [SerializeField] private TMP_Text tipText = null;

    WinCondition winCondition;

    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
    }

    private void Update()
    {
        if (tipsArray.Length >= winCondition.currentWave - 1)
        {
            tipText.text = tipsArray[(winCondition.currentWave - 2)];
        }
        else
        {
            tipText.text = "Good Luck!";
        }

    }
}
