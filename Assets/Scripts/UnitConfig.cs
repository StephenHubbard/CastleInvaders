using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Make New Unit", order = 0)]
public class UnitConfig : ScriptableObject
{
    [SerializeField] public string unitName = null;
    [SerializeField] public int damage = 1;
    [SerializeField] public bool isEnemy = false;
    [SerializeField] public GameObject unitPrefab = null;
    [SerializeField] public int startingHealth = 3;

    public int GetDamage()
    {
        return damage;
    }

    public bool GetIsEnemy()
    {
        return isEnemy;
    }
}
