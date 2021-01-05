using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] public UnitConfig unitConfig;

    private int moveDirection;

    Animator myAnimator;
    Collider2D myCollider;

    private GameObject myAttacker;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        SetMoveDirection();
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
        Vector2 characterVelocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = characterVelocity;
    }

    public void Attack()
    {
        Health myAttackerHealth = myAttacker.GetComponent<Health>();
        myAttackerHealth.TakeDamage(unitConfig.damage);
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
