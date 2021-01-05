using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public UnitConfig unitConfig;

    private void Start()
    {
        StartCoroutine(SpawnUnitsTimer());
    }

    private IEnumerator SpawnUnitsTimer()
    {
        SpawnEnemyUnit();
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnUnitsTimer());

    }

    private void SpawnEnemyUnit()
    {
        float randomYOffset = Random.Range(-5f, 5f);
        Vector3 newSpawnPosition = new Vector2(transform.position.x, transform.position.y + randomYOffset);

        Instantiate(unitConfig.unitPrefab, newSpawnPosition, transform.rotation);
    }
}
