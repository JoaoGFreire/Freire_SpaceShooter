using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float radius;
    public float speed;
    private float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, speed,planetTransform);
    }
    public void OrbitalMotion(float radius,float speed, Transform target)
    {
        angle += speed * Time.deltaTime; //angle increases by the speed times Time.deltaTime
        if(angle >= 360) //makes sure to reset the angle to 0 in case it reaches a number higher then 360
        {
            angle -= 360; 
        }
        float RadiansAngle = angle * Mathf.Deg2Rad; //transforms the angle to radians
        Vector3 position = new Vector3(Mathf.Cos(RadiansAngle) * radius, Mathf.Sin(RadiansAngle) * radius, 0) + target.position;
        //position for the moon will be its current position plus a vector3 made up of the cosine of angle times the radius and the sine of the angle times the radius
        transform.position = position;
        //sets the transform position to the newly calculated position.
    }
}
