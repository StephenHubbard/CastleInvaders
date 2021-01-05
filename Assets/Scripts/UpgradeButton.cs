using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image checkMarkImage = null;
    [SerializeField] BuyUnitButton buyUnitButton;

    private void Start()
    {
        
    }

    private void Update()
    {
        checkIfUnlocked();
    }


    private void checkIfUnlocked()
    {
        if (buyUnitButton.isUnlocked)
        {
            checkMarkImage.gameObject.SetActive(true);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            checkMarkImage.gameObject.SetActive(false);
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
