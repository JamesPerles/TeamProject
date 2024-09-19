using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour
{
    Vector3 mousePosition = Input.mousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
        //Got this from gamedevbeginner.com. Idk if this works yet
        //This causes the projectile to immediately target the mouse/reticle
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //Sprite change? May not have enough time.
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   
            //Destroy(collision.gameObject);
            //Also, this needs to destroy the enemy of course
        }
        
        if (collision.gameObject.tag == "Terrain")
        {   
            //Destroy(collision.gameObject);
            //This just deletes the proj to prevent pre-emptive killing
        }
        
        if (collision.gameObject.tag == "Hazard")
        {   
            //Destroy(collision.gameObject);
        }
        //These lines were also reused from Swingo's Speedrun. Thank you Misha!
        //Need a little help on movement
        
    }
}
