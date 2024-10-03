using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    private float timer;
    private LevelProgress LP;
    public float timetillDisappear = 4f;
    // Start is called before the first frame update
    void Start()
    {
        timer = timetillDisappear;
        LP = FindObjectOfType<LevelProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y -= LP.BackgroundSpeed * Time.deltaTime;
        transform.position = newPos;
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(gameObject); //Get rid of the blood splatter when enough time has passed
    }
}
