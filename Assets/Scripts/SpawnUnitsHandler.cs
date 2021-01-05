using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnitsHandler : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint = null;
    [SerializeField] private GameObject Knight1_prefab = null;

    [SerializeField] GoldHandler goldHandler = null;


    public void spawnKnight1()
    {
        goldHandler.currentGold = goldHandler.currentGold - 10;

        float randomYOffset = Random.Range(-3.5f, 3.5f);
        Vector3 newSpawnPosition = new Vector2(spawnPoint.position.x, spawnPoint.position.y + randomYOffset);

        Instantiate(Knight1_prefab, newSpawnPosition, transform.rotation);

        goldHandler.UpdateCurrentGold();
    }
}
