using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public LevelProgress LP;

    private List<bool> SpawnedAlready = new List<bool>(){false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        return;
        if (LP.Level != 1) return; //if the player isn't on level one then dont do anything
        if (LP.CurrentProgress >= 90f && !SpawnedAlready[4]) SpawnedAlready[4] = true; //Spawn Boss
        else if (LP.CurrentProgress >= 70f && !SpawnedAlready[3]) SpawnedAlready[3] = true; //Spawn Enemies
        else if (LP.CurrentProgress >= 50f && !SpawnedAlready[2]) SpawnedAlready[2] = true; //Spawn Enemies
        else if (LP.CurrentProgress >= 30f && !SpawnedAlready[1]) SpawnedAlready[1] = true; //Spawn Enemies
        else if (LP.CurrentProgress >= 10f && !SpawnedAlready[0]) SpawnedAlready[0] = true; //Spawn Enemies

    }
}
