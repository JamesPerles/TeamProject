using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    private Transform player; // Reference to the player
    public float moveSpeed = 2f; // Speed of enemy movement

    void Start()
    {
        // Find the player by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            // Calculate the direction vector and normalize it
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for collision with the player
        if (collision.gameObject.tag == "Player")
        {
            // Destroy the enemy on collision with the player
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            // Destroy the enemy on collision with the bullet
            Destroy(gameObject);
        }
    }
}