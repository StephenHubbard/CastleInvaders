using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttacker : MonoBehaviour
{
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private float fireDistance = 100f;
    [SerializeField] private GameObject fireballPrefab = null;


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
            unitMovement.isAttacking = true;
        }
        else
        {
            //unitMovement.isAttacking = false;
        }
    }

    private void CheckIfTargetInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, Vector2.right, fireDistance);

        Debug.DrawRay(firePoint.position, Vector2.right * fireDistance, Color.green);

        if (hit)
        {
            if (hit.transform.gameObject.CompareTag("Unit"))
            {
                hitEnemy = hit.transform.gameObject;
                myAnimator.SetBool("isAttacking", true);

            }
            else
            {
                hitEnemy = null;
                myAnimator.SetBool("isAttacking", false);
            }
        }
    }

    public void FireProjectile()
    {
        Instantiate(fireballPrefab, firePoint.position, transform.rotation);
    }

    
}
