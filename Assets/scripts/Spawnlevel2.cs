using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnlevel2 : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] spawnPointswasp;
    public GameObject[] bees;
    public GameObject[] wasp;

    void Start()
    {
        StartCoroutine(StartSpawning());
        StartCoroutine(StartSpawningwasp());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 4; i++)
        {
            Instantiate(bees[i], spawnPoints[i].position, spawnPoints[i].rotation);
          
        }
       
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawningwasp()
    {
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 2; i++)
        {
            Instantiate(wasp[i], spawnPointswasp[i].position, spawnPointswasp[i].rotation);
        }

        StartCoroutine(StartSpawningwasp());
    }
}
