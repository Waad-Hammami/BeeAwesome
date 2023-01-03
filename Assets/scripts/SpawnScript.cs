using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] bees;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(4);

    for (int i = 0; i<3; i++)
        {
            Instantiate(bees[i], spawnPoints[i].position, spawnPoints[i].rotation);
        }
        StartCoroutine(StartSpawning());
        
    } 

}
