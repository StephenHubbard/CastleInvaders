using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public UnitConfig unitConfig;
    [SerializeField] private GameObject spawnUnitsContainer = null;
    [SerializeField] private int unitsToSpawnThisWave;

    private WinCondition winCondition;



    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        unitsToSpawnThisWave = winCondition.enemiesLeft;
        StartCoroutine(SpawnUnitsTimer());
    }

    public void startNewRound()
    {
        unitsToSpawnThisWave = winCondition.enemiesLeft;

        StartCoroutine(SpawnUnitsTimer());
    }

    private IEnumerator SpawnUnitsTimer()
    {
        if (winCondition.roundComplete == false && unitsToSpawnThisWave > 0)
        {
            SpawnEnemyUnit();
            yield return new WaitForSeconds(2f);
            StartCoroutine(SpawnUnitsTimer());
        }
    }

    private void SpawnEnemyUnit()
    {
        unitsToSpawnThisWave--;
        winCondition.enemiesLeft--;
        float randomYOffset = Random.Range(-4f, 4f);
        Vector3 newSpawnPosition = new Vector2(transform.position.x, transform.position.y + randomYOffset);

        GameObject newSpawn = Instantiate(unitConfig.unitPrefab, newSpawnPosition, transform.rotation);
        newSpawn.transform.parent = spawnUnitsContainer.transform;
    }
}
