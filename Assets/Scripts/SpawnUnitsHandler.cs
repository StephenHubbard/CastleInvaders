using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnUnitsHandler : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint = null;
    [SerializeField] private GameObject spawnUnitsContainer = null;
    [SerializeField] GoldHandler goldHandler = null;
    [SerializeField] public int maxAmountOfFriendlyUnits = 3;
    [SerializeField] Transform spawnedUnitsContainerFriendly = null;
    [SerializeField] TMP_Text currentAmountLeftText = null;


    private int maxAmountLeft;

    private GoldConjuror goldConjuror;

    private void Start()
    {
        goldConjuror = FindObjectOfType<GoldConjuror>();
        newWaveStart();
    }

    private void Update()
    {
        maxAmountLeft = maxAmountOfFriendlyUnits - spawnedUnitsContainerFriendly.childCount - goldConjuror.amountOfConjurors;

        currentAmountLeftText.text = $"{maxAmountLeft.ToString()}";
    }

    public void newWaveStart()
    {
        maxAmountLeft = maxAmountOfFriendlyUnits;
    }

    public void SpawnFriendlyUnit(UnitConfig unitConfig)
    {
        maxAmountLeft = returnMaxAmountLeft();

        if (goldHandler.currentGold < unitConfig.goldCost) { return; }

        if (maxAmountLeft <= 0) { return; }

        goldHandler.currentGold = goldHandler.currentGold - unitConfig.goldCost;

        float randomYOffset = Random.Range(-4f, 4f);
        Vector3 newSpawnPosition = new Vector2(spawnPoint.position.x, spawnPoint.position.y + randomYOffset);

        GameObject newSpawn = Instantiate(unitConfig.unitPrefab, newSpawnPosition, transform.rotation);
        newSpawn.transform.parent = spawnUnitsContainer.transform;

        maxAmountLeft = returnMaxAmountLeft();


        goldHandler.UpdateCurrentGold();
    }

    public void SpawnGoldConjuror()
    {
        maxAmountLeft = returnMaxAmountLeft();

        if (maxAmountLeft <= 0) { return; }

        GoldConjuror goldConjuror = FindObjectOfType<GoldConjuror>();
        goldConjuror.amountOfConjurors++;
    }

    private int returnMaxAmountLeft()
    {
        maxAmountLeft = maxAmountOfFriendlyUnits - spawnedUnitsContainerFriendly.childCount - goldConjuror.amountOfConjurors;

        return maxAmountLeft;
    }
}
