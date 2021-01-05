using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinCondition : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] public int enemiesLeft = 10;

    private void Start()
    {
        
    }

    private void Update()
    {
        updateSlider();
        checkWinCondition();
    }

    private void updateSlider()
    {
        slider.value = enemiesLeft;
    }

    private void checkWinCondition()
    {
        if (slider.value <= 0)
        {
            print("round complete");
        }
    }

}
