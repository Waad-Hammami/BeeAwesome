using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeesScripts : MonoBehaviour
{
   
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 0.7f);
    }

}
