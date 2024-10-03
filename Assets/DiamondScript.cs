using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public float Health = 5f;
    private Transform player; // Reference to the player
    public float moveSpeed = 2f; // Speed of enemy movement
    public float stoppingDistance = 4f; // Distance to stop before reaching the player
    public GameObject projectilePrefab; // Projectile prefab to fire
    public GameObject BloodPrefab;
    public float fireRate = 3.5f; // Rate of fire (time between shots)
    private AngelScript AS;

    private float nextFireTime; // Timer for firing projectiles

    // Projectile properties
    public float projectileSpeed = 10f; // Speed of the projectile
    public float projectileLifetime = 5f; // Lifetime of the projectile

    void Start()
    {
        AS = FindObjectOfType<AngelScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
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

        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Health--;
            if (Health <= 0)
            {
                GameObject temp = Instantiate(BloodPrefab, transform.position, Quaternion.identity);
                int rand = Random.Range(1, 4); //get a random number so the blood splatter has a random sprite when spawned
                Debug.Log(rand);
                if (rand == 1) temp.GetComponent<SpriteRenderer>().sprite = AS.Blood1;
                if (rand == 2) temp.GetComponent<SpriteRenderer>().sprite = AS.Blood2;
                if (rand == 3) temp.GetComponent<SpriteRenderer>().sprite = AS.Blood3;
                Destroy(gameObject); // Destroy the enemy on collision with the bullet
            }
        }
    }
}
