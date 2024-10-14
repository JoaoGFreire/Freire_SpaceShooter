using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTurret : MonoBehaviour
{
    public float angularSpeed;
    public float timer = 0;
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
        transform.Rotate(0,0,angularSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            Debug.Log("hello");
            Instantiate(misslePrefab,Spawn.transform.position,Spawn.transform.rotation);

            timer = 0;
        }
    }
}
