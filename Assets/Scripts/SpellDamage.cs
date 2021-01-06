using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    [SerializeField] public int ExplosionSpellDamage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>().TakeDamage(ExplosionSpellDamage);
    }
}
