using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour

{
    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 vel = new Vector2();
        //{
            //vel.y = -5;
        //} 
        transform.Velocity(.4f * Time.deltaTime, -1, -1);
        //Found on https://discussions.unity.com/t/how-to-make-an-object-move-constantly-como-hacer-para-que-un-objeto-se-mueva-constantemente/839129
        //I want to replace with my own code

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "BounceWall")
        //{
        //START MOVING FROM SIDE TO SIDE
        //}
    }
}
