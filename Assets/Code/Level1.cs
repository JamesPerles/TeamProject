using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public LevelProgress LP;
    public GameObject SP1;
    public GameObject SP2;
    public GameObject SP3;
    public GameObject SP4;
    public GameObject SP5;
    public GameObject SP6;
    private Vector3 Point1;
    private Vector3 Point2;
    private Vector3 Point3;
    private Vector3 Point4;
    private Vector3 Point5;
    private Vector3 Point6;

    private List<bool> SpawnedAlready = new List<bool>(){false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        LP = FindObjectOfType<LevelProgress>();
        Point1 = SP1.transform.position;
        Point2 = SP2.transform.position;
        Point3 = SP3.transform.position;
        Point4 = SP4.transform.position;
        Point5 = SP5.transform.position;
        Point6 = SP6.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (LP.CurrentProgress >= 85f && !SpawnedAlready[4])
        {
            SpawnedAlready[4] = true;
            StartCoroutine(LP.SpawnEnemies(Point1, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point2, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point3, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point4, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point5, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point6, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point1, 2, 3f));
            StartCoroutine(LP.SpawnEnemies(Point6, 2, 3f));
        }
        else if (LP.CurrentProgress >= 65f && !SpawnedAlready[3])
        {
            SpawnedAlready[3] = true;
            StartCoroutine(LP.SpawnEnemies(Point3, 4, 1f));
            StartCoroutine(LP.SpawnEnemies(Point6, 1, 2f));
            StartCoroutine(LP.SpawnEnemies(Point2, 2, 2f));
            StartCoroutine(LP.SpawnEnemies(Point5, 1, 2f));
        }
        else if (LP.CurrentProgress >= 45f && !SpawnedAlready[2])
        {
            SpawnedAlready[2] = true;
            StartCoroutine(LP.SpawnEnemies(Point1, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point6, 2, 1f));
            StartCoroutine(LP.SpawnEnemies(Point3, 2, 3f));
            StartCoroutine(LP.SpawnEnemies(Point5, 2, 3f));
        }
        else if (LP.CurrentProgress >= 25f && !SpawnedAlready[1])
        {
            SpawnedAlready[1] = true;
            StartCoroutine(LP.SpawnEnemies(Point4, 3, 3f));
            StartCoroutine(LP.SpawnEnemies(Point6, 3, 2f));
        }
        else if (LP.CurrentProgress >= 10f && !SpawnedAlready[0])
        {
            SpawnedAlready[0] = true;
            StartCoroutine(LP.SpawnEnemies(Point1, 2, 2f));
            StartCoroutine(LP.SpawnEnemies(Point5, 2, 2f));
            StartCoroutine(LP.SpawnEnemies(Point3, 1, 2f));
        }

    }


}
