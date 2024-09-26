using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public float CurrentProgress; //Stored as a percent

    public int Level; //Which level te player is on
    public int TotalLevels = 1;
    public float currentSpeed = 2f; //the speed at which the player is moving through the level, percent per second
    public bool Moving = false; //if the player is currently moving through the level

    private AngelScript AS;
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
        }
    }
}
