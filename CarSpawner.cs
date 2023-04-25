using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] prefabs; //Drag all car prefabs here
    public float startTime;
    public float spawnRate;
    int random;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
    }

    void Spawn(){
        random = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[random], transform.position, transform.rotation);
    }

}
