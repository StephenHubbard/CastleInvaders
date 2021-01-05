using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnitsHandler : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint = null;

    [SerializeField] GoldHandler goldHandler = null;

    [SerializeField] UnitConfig unitConfig_Knight_1 = null;


    public void spawnKnight1()
    {
        if (goldHandler.currentGold < unitConfig_Knight_1.goldCost) { return; }

        goldHandler.currentGold = goldHandler.currentGold - unitConfig_Knight_1.goldCost;

        float randomYOffset = Random.Range(-5f, 5f);
        Vector3 newSpawnPosition = new Vector2(spawnPoint.position.x, spawnPoint.position.y + randomYOffset);

        Instantiate(unitConfig_Knight_1.unitPrefab, newSpawnPosition, transform.rotation);

        goldHandler.UpdateCurrentGold();
    }
}
