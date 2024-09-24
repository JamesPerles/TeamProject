using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelScript : MonoBehaviour
{
    public int MaxHealth = 5;
    public int health;
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
            vel.y = 5;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -5;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            vel.y = -5;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 5;
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
