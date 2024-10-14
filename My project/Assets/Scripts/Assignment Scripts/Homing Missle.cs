using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 40f;

    public Color color;
    Vector3 velocity;

    public float homingRadius;
    GameObject Player;

    public float angularSpeed;
    public float targetAngle;


    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.up * speed;
        transform.position += transform.up * Time.deltaTime;
        DrawHomingRange();
        Home();

    }
    public bool inRange()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < homingRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void DrawHomingRange()
    {
        if(inRange())
        {
            color = Color.red;
        }
        else
        {
            color = Color.white;
        }
        
        
        float n = 360 / 20;
        Vector3 offset = new Vector3(homingRadius, 0, 0);
        Vector3 Point = transform.position + offset;
        for (int i = 0; i <= 20; i++)
        {
            float angle = (n * i) * Mathf.Deg2Rad;
            Vector3 nextPoint = transform.position + new Vector3(Mathf.Cos(angle) * homingRadius, Mathf.Sin(angle) * homingRadius, 0f);

            Debug.DrawLine(Point, nextPoint, color);
            Point = nextPoint;

        }
    }

    public void Home()
    {
        if (inRange())
        {
            Vector3 target = Player.transform.position - transform.position;
            targetAngle= Mathf.Atan2(target.y,target.x) * Mathf.Rad2Deg;

            if (transform.eulerAngles.z > targetAngle)
            {
                transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
            }
            if (transform.eulerAngles.z < targetAngle)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
            }


        }
    }
}
