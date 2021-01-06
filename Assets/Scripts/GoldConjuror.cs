using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldConjuror : MonoBehaviour
{
    [SerializeField] TMP_Text amountText = null;
    [SerializeField] public int amountOfConjurors = 0;
    [SerializeField] private int goldPerConjuror = 10;

    public GoldHandler goldHandler;

    private void Start()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(IncreaseGold());
    }

    private void Update()
    {
        amountText.text = amountOfConjurors.ToString();
    }

    private IEnumerator IncreaseGold()
    {
        goldHandler.currentGold = goldHandler.currentGold + (amountOfConjurors * goldPerConjuror);
        yield return new WaitForSeconds(1f);
        StartCoroutine(IncreaseGold());

    }
}
