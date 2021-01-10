using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tips : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] private string[] tipsArray;
    [SerializeField] private TMP_Text tipText = null;

    [SerializeField] private int randomTip;

    WinCondition winCondition;

    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();

        randomTip = Random.Range(0, tipsArray.Length);
    }

    private void Update()
    {
        tipText.text = tipsArray[(randomTip)];
    }

    public void newTip()
    {
        randomTip = Random.Range(0, tipsArray.Length);
    }

}
