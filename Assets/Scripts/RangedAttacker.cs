using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttacker : MonoBehaviour
{
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private float fireDistance = 100f;
    [SerializeField] private GameObject fireballPrefab = null;

    [SerializeField] private LayerMask[] ignoredLayers;


    Animator myAnimator;
    UnitMovement unitMovement;

    [SerializeField] private GameObject hitEnemy = null;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        unitMovement = GetComponent<UnitMovement>();
    }

    void Update()
    {
        CheckIfTargetInRange();
        CheckIfAttacking();
    }

    private void CheckIfAttacking()
    {
        if (hitEnemy)
        {
            if (hitEnemy.GetComponent<Health>().currentHealth <= 0)
            {
                hitEnemy = null;
            }
        }


        if (hitEnemy)
        {
            unitMovement.isAttacking = true;
            myAnimator.SetBool("isAttacking", true);

        }
        else
        {
            unitMovement.isAttacking = false;
            myAnimator.SetBool("isAttacking", false);

        }
    }

    private void CheckIfTargetInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, Vector2.right, fireDistance, ~ignoredLayers[0], ~ignoredLayers[1]);

        Debug.DrawRay(firePoint.position, Vector2.right * fireDistance, Color.green);


        if (!hit)
        {
            hitEnemy = null;
            return;
        }

        if (hit.transform.gameObject.GetComponent<Enemy>())
        {
            hitEnemy = hit.transform.gameObject;
        }
        else
        {
            hitEnemy = null;
        }
    }

    public void FireProjectile()
    {
        Instantiate(fireballPrefab, firePoint.position, transform.rotation);
    }

    
}
