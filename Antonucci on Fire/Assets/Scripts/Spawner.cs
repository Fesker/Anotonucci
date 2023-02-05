using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> spawneables;

    void Start()
    {
       Spawn(); 
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         
    //     }
    // }

    void Spawn()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            //GameObject spawneableGo = spawneables[Random.Range(0, spawnPoints.Count - 1)];
            GameObject spawneableGo = spawneables[Random.Range(0, 5)];
            Instantiate(spawneableGo, spawnPoint.transform.position, spawneableGo.transform.rotation);
        }
    }
}
