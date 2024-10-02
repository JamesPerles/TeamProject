using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    private Transform player; // Reference to the player
    public float moveSpeed = 2f; // Speed of enemy movement
    public float stoppingDistance = 2f; // Distance to stop before reaching the player
    public GameObject projectilePrefab; // Projectile prefab to fire
    public float fireRate = 1f; // Rate of fire (time between shots)

    private float nextFireTime; // Timer for firing projectiles

    // Projectile properties
    public float projectileSpeed = 5f; // Speed of the projectile
    public float projectileLifetime = 5f; // Lifetime of the projectile

    void Start()
    {
        // Find the player by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time; // Initialize next fire time
    }

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            // Calculate the distance to the player
            float distance = Vector2.Distance(transform.position, player.position);

            // Check if we are within stopping distance
            if (distance > stoppingDistance)
            {
                // Calculate the direction vector and normalize it
                Vector2 direction = (player.position - transform.position).normalized;

                // Move the enemy towards the player
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                // Fire projectiles at the player
                if (Time.time >= nextFireTime)
                {
                    FireProjectile();
                    nextFireTime = Time.time + fireRate; // Reset the next fire time
                }
            }
        }
    }

    void FireProjectile()
    {
        if (projectilePrefab != null)
        {
            // Instantiate the projectile and set its position
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            // Set the projectile's direction and speed
            Vector2 direction = (player.position - transform.position).normalized;

            // Calculate the velocity for the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed; // Set the projectile velocity
            }

            // Destroy the projectile after its lifetime
            Destroy(projectile, projectileLifetime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for collision with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the enemy on collision with the player
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the enemy on collision with the bullet
            Destroy(gameObject);
        }
    }
}
