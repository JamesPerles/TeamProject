using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class AngelScript : MonoBehaviour
{
    public int MaxHealth = 5;
    public int health;
    public float speed = 5f;
    public Sprite Blood1;
    public Sprite Blood2;
    public Sprite Blood3;
    public Rigidbody2D RB;
    public AudioSource AS;
    public AudioClip A1;
    public AudioClip A2;
    public AudioClip A3;
    public AudioClip B1;
    public AudioClip B2;
    public AudioClip B3;

    public AudioClip deathSound; // Sound effect for when health reaches zero

    // To James, no definitive amount of sounds needed yet, placeholders for now
    void Start()
    {
        health = MaxHealth;
    }

    void Update()
    {
        Vector2 vel = new Vector2();

        // WASD movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = speed;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -speed;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -speed;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Fire laser or other projectile somehow
        }

        RB.velocity = vel;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet")) // Collision with an enemy bullet
        {
            health -= 1; // Reduce health by 1
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                PlayDeathSound(); // Play death sound effect
                Invoke("LoadGameOverScene", deathSound.length); // Load GameOver scene after sound
            }
        }

        if (collision.gameObject.tag == "Hazard")
        {
            // Handle hazard collisions (slow down player, etc.)
        }

        if (collision.gameObject.name == "LevelEnd")
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Play the death sound effect when health reaches zero
    void PlayDeathSound()
    {
        if (AS != null && deathSound != null)
        {
            AS.PlayOneShot(deathSound); // Play the death sound effect
        }
    }

    // Load the GameOver scene after the death sound plays
    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}

