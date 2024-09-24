using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{
    public float spinSpeed = 10f;
    public float currentRot;
    public bool shouldRotate = true;
    void Start()
    {
        Cursor.visible = false;
        currentRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //finds the mouse's position as a place in the game
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); //sets the reticle's position to the mouse's
        currentRot += spinSpeed * Time.deltaTime; //adds spin based on a number of degrees per second
        if (shouldRotate)
        {
            if (currentRot > 360f) //loops around when it gets to 360
            {
                float temp = currentRot - 360f;
                currentRot = temp;
            }

            transform.localEulerAngles = new Vector3(0f, 0f, currentRot); //sets it to the rotation of the reticle
        }
        //This is what persistently guides the reticle to the mouse
        //in-engine spinning animation? IDK
    }
}
