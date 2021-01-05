using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public UnitConfig unitConfig;
    [SerializeField] private GameObject spawnUnitsContainer = null;

    private WinCondition winCondition;


    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        StartCoroutine(SpawnUnitsTimer());
    }

    public void startNewRound()
    {
        StartCoroutine(SpawnUnitsTimer());
    }

    private IEnumerator SpawnUnitsTimer()
    {
        if (winCondition.roundComplete == false)
        {
            SpawnEnemyUnit();
            yield return new WaitForSeconds(2f);
            StartCoroutine(SpawnUnitsTimer());
        }
    }

    private void SpawnEnemyUnit()
    {
        float randomYOffset = Random.Range(-4f, 4f);
        Vector3 newSpawnPosition = new Vector2(transform.position.x, transform.position.y + randomYOffset);

        GameObject newSpawn = Instantiate(unitConfig.unitPrefab, newSpawnPosition, transform.rotation);
        newSpawn.transform.parent = spawnUnitsContainer.transform;
    }
}
