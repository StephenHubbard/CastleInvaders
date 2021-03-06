﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] public int enemiesLeft = 10;
    [SerializeField] GameObject newWaveTextContainer = null;
    [SerializeField] TMP_Text newWaveText = null;
    [SerializeField] GameObject waveCompleteGameObject = null;
    [SerializeField] private GameObject spawnUnitsContainer = null;
    [SerializeField] private Transform SpawnedUnitsContainerEnemy = null;
    [SerializeField] GameObject gameOverText = null;
    [SerializeField] Health castleHealth = null;

    private EnemySpawner enemySpawner;
    private GoldHandler goldHandler;
    private SpawnUnitsHandler spawnUnitsHandler;
    private GoldConjuror goldConjuror;
    private SpellHandler spellHandler;
    private Tips tips;


    public int currentWave = 1;
    public float enemyExponentialDifficulty = 0f;

    public bool roundComplete = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        goldHandler = FindObjectOfType<GoldHandler>();
        spawnUnitsHandler = FindObjectOfType<SpawnUnitsHandler>();
        goldConjuror = FindObjectOfType<GoldConjuror>();
        spellHandler = FindObjectOfType<SpellHandler>();
        tips = FindObjectOfType<Tips>();

        UpdateSliderMaxValue();
    }

    private void Update()
    {
        updateSlider();
        if (roundComplete == false)
        {
            checkWinCondition();
        }

        CheckIfPlayerLose();
    }

    private void CheckIfPlayerLose()
    {
        if (castleHealth.currentHealth <= 0)
        {
            gameOverText.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void StartOverButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private void updateSlider()
    {
        slider.value = enemiesLeft;
    }

    private void checkWinCondition()
    {
        if (slider.value <= 0 && !checkIfEnemiesExist())
        {
            waveCompleteGameObject.SetActive(true);

            foreach (Transform child in spawnUnitsContainer.transform)
            {
                Destroy(child.gameObject);
            }

            roundComplete = true;

            currentWave++;

        }
    }

    private bool checkIfEnemiesExist()
    {
        if (SpawnedUnitsContainerEnemy.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShowNewWaveText()
    {
        waveCompleteGameObject.SetActive(false);

        newWaveTextContainer.SetActive(true);

        newWaveText.text = $"Wave {currentWave} Incoming!";

        StartNextRound();
    }


    public void StartNextRound()
    {
        Invoke("startNewRound", 2f);
    }


    private void startNewRound()
    {
        goldHandler.newWaveGold();

        spawnUnitsHandler.newWaveStart();

        spellHandler.explosionSpells = 1;

        //goldConjuror.amountOfConjurors = 0;

        tips.newTip();

        enemyExponentialDifficulty = Mathf.Pow(1.2f, currentWave);

        newWaveTextContainer.SetActive(false);

        roundComplete = false;

        enemiesLeft = enemiesLeft + currentWave;

        UpdateSliderMaxValue();

        enemySpawner.startNewRound();
    }

    private void UpdateSliderMaxValue()
    {
        slider.maxValue = enemiesLeft;
    }


}
