using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;

    Vector2 currentVelocity;
    //from gamedevbeginner.com
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
        
        //This is what persistently guides the reticle to the mouse
        //in-engine spinning animation? IDK
    }
}
