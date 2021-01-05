using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WinCondition : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] public int enemiesLeft = 10;
    [SerializeField] GameObject newWaveTextContainer = null;
    [SerializeField] TMP_Text newWaveText = null;
    [SerializeField] GameObject waveCompleteGameObject = null;
    [SerializeField] private GameObject spawnUnitsContainer = null;

    private EnemySpawner enemySpawner;
    private GoldHandler goldHandler;

    public int currentRound = 1;

    public bool roundComplete = false;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        goldHandler = FindObjectOfType<GoldHandler>();

        UpdateSliderMaxValue();
    }

    private void Update()
    {
        updateSlider();
        if (roundComplete == false)
        {
            checkWinCondition();
        }
    }


    private void updateSlider()
    {
        slider.value = enemiesLeft;
    }

    private void checkWinCondition()
    {
        if (slider.value <= 0)
        {
            waveCompleteGameObject.SetActive(true);

            foreach (Transform child in spawnUnitsContainer.transform)
            {
                Destroy(child.gameObject);
            }

            roundComplete = true;

            currentRound++;

        }
    }

    public void ShowNewWaveText()
    {
        waveCompleteGameObject.SetActive(false);

        newWaveTextContainer.SetActive(true);

        newWaveText.text = $"Wave {currentRound} Incoming!";

        StartNextRound();
    }


    public void StartNextRound()
    {
        Invoke("startNewRound", 2f);
    }


    private void startNewRound()
    {

        goldHandler.newWaveGold();

        newWaveTextContainer.SetActive(false);

        roundComplete = false;

        enemiesLeft = enemiesLeft + currentRound * 2;

        UpdateSliderMaxValue();

        enemySpawner.startNewRound();
    }

    private void UpdateSliderMaxValue()
    {
        slider.maxValue = enemiesLeft;
    }


}
