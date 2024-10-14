using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTurret : MonoBehaviour
{
    public float timer;
    public float interval;
    public GameObject misslePrefab;
    public GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            Instantiate(misslePrefab, Spawn.transform.position, Spawn.transform.rotation);
            timer = 0;
        }
    }
}

