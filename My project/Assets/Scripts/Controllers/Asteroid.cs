using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 RandomPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        RandomPoint.x = Random.Range(transform.position.x, maxFloatDistance);
        RandomPoint.y = Random.Range(transform.position.y, maxFloatDistance);

    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        
        Debug.Log(RandomPoint);
        moveSpeed = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, RandomPoint, moveSpeed);
    }
}
