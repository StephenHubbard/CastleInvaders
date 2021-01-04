using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int moveDirection = 1;
    [SerializeField] Rigidbody2D rb = null;

    void Start()
    {
        
    }

    void Update()
    {
        moveCharacter();
    }

    private void moveCharacter()
    {
        Vector2 characterVelocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = characterVelocity;

        //bool characterHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        
    }
}
