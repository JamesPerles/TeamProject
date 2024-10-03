using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelProgress : MonoBehaviour
{
    public float CurrentProgress; //Stored as a percent

    public int Level; //Which level te player is on
    public int TotalLevels = 1;
    public float currentSpeed = 2f; //the speed at which the player is moving through the level, percent per second
    public float BackgroundSpeed = 4f;
    public Vector3 BG1Pos;
    public Vector3 BG2Pos;
    public bool Moving = false; //if the player is currently moving through the level

    private AngelScript AS;
    public GameObject Background1;
    public GameObject Background2;
    // Start is called before the first frame update
    void Start()
    {
        AS = FindObjectOfType<AngelScript>();
        Level = 1;
        Moving = false;
        CurrentProgress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving) //when the player is going through the level, wont happen when fighting a boss for example
        {
            CurrentProgress += currentSpeed * Time.deltaTime;
            if (CurrentProgress > 100f) //level has been completed
            {
                Level++; //go to the next level
                AS.health = AS.MaxHealth; //reset player health
                if (Level > TotalLevels) Application.Quit();
            }
            Vector3 newPos = Background1.transform.position;
            newPos.y = newPos.y - (BackgroundSpeed * Time.deltaTime);
            Background1.transform.position = newPos;
            newPos = Background2.transform.position;
            newPos.y = newPos.y - (BackgroundSpeed * Time.deltaTime);
            Background2.transform.position = newPos;
            if (Mathf.Abs(Background2.transform.position.y - 14f) < 1f)
            {
                Background1.transform.position = new Vector3(Background2.transform.position.x, Background2.transform.position.y + 51.00005f, 0f);
                GameObject temp = Background1;
                Background1 = Background2;
                Background2 = temp;
            }
        }
    }
}
