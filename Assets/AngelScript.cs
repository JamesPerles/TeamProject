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

    //To James, no definitive amount of sounds needed yet, placeholders for now
    void Start()
    {
        health = MaxHealth;
    }

    
    void Update()
    {
        Vector2 vel = new Vector2();
        //Damn it's been a while since I did any coding so I'm kinda rusty on how to do movement
        if (Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = speed;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            //Fire laser or other projectile somehow
        }
        
        RB.velocity = vel;
        //All code in this section was reused from Swingo's Speedrun, with Misha's help 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet")) // Collision with an enemy
        {
            health -= 1; // Reduce health by 1
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                // Load GameOver scene when health reaches 0
                SceneManager.LoadScene("GameOver");
            }
        }

        if (collision.gameObject.tag == "Hazard")
        {   
            //Destroy(collision.gameObject);      We also need to incorporate the player angel slowing down every time he gets hurt.
        }
        
        if (collision.gameObject.name == "LevelEnd")
        {   
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //These lines were also reused from Swingo's Speedrun. Thank you Misha!
        //Need a little help on movement
        
    }
    
    //COMING SOON: Enemy movement properties, scrolling background, halo reticle and aiming system.
    //Christian, we also need a projectile sprite
    
}
