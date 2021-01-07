using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] public UnitConfig unitConfig;
    [SerializeField] private float modifiedDamage;

    private int moveDirection;
    public bool isAttacking = false;

    Animator myAnimator;
    Collider2D myCollider;

    private GameObject myAttacker;
    private WinCondition winCondition;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        winCondition = FindObjectOfType<WinCondition>();

        modifiedDamage = unitConfig.damage + (winCondition.enemyExponentialDifficulty / 3);

        SetMoveDirection();
        SetMoveSpeed();
    }

    private void SetMoveSpeed()
    {
        moveSpeed = unitConfig.moveSpeed;
    }

    private void SetMoveDirection()
    {
        if (unitConfig.isEnemy == true)
        {
            moveDirection = -1;
        }
        else if (unitConfig.isEnemy == false)
        {
            moveDirection = 1;
        }
    }

    void Update()
    {
        moveCharacter();
    }

    private void moveCharacter()
    {
        if (isAttacking == false)
        {
            Vector2 characterVelocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y) * Time.deltaTime;
            rb.velocity = characterVelocity;
        }
        else
        {
            Vector2 characterVelocity = new Vector2(moveDirection * 0, rb.velocity.y) * Time.deltaTime;
            rb.velocity = characterVelocity;
        }
    }

    public void Attack()
    {
        Health myAttackerHealth = myAttacker.GetComponent<Health>();
        myAttackerHealth.TakeDamage(unitConfig.damage);
    }

    public void EnemyAttack()
    {
        Health myAttackerHealth = myAttacker.GetComponent<Health>();
        myAttackerHealth.TakeDamage((int)modifiedDamage);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Unit"))
        {
            myAnimator.SetBool("isAttacking", true);
            myAttacker = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        myAnimator.SetBool("isAttacking", false);
    }
}
