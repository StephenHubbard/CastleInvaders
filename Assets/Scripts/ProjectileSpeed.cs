using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeed : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private Rigidbody2D rb = null;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 projectileVelocity = new Vector2(projectileSpeed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = projectileVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
