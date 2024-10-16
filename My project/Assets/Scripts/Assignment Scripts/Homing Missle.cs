using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 40f; //speed for missile

    public Color color; // color variable for easy switching of colors
    Vector3 velocity;

    public float homingRadius; //range for the homing to activate
    GameObject Player; // gameobject to represent the player

    public float angularSpeed; //rotation speed
    public float targetAngle; //angle of the target (in this case the player)


    void Start()
    {
        Player = GameObject.Find("Player"); //finds the gameObject player in the scene and asigns it to the Player variable 
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.up * speed;
        transform.position += transform.up * Time.deltaTime; // missile moves
        DrawHomingRange();
        Home();

    }
    public bool inRange()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < homingRadius) // is the player inside the range of the homing missle
        {
            return true; //if so return true
        }
        else
        {
            return false; //if not return false
        }
    }
    public void DrawHomingRange()
    {
        if(inRange()) //in in range is true...
        {
            color = Color.red; // circle is red if player is in range
        }
        else
        {
            color = Color.white; // circle is white player isnt in range
        }
        
        
        float n = 360 / 20;
        Vector3 offset = new Vector3(homingRadius, 0, 0);
        Vector3 Point = transform.position + offset;
        for (int i = 0; i <= 20; i++)
        {
            float angle = (n * i) * Mathf.Deg2Rad;
            Vector3 nextPoint = transform.position + new Vector3(Mathf.Cos(angle) * homingRadius, Mathf.Sin(angle) * homingRadius, 0f);

            Debug.DrawLine(Point, nextPoint, color); //draws the circle at the color specified in the begining of the method
            Point = nextPoint;

        }
    }

    public void Home()
    {
        if (inRange()) //if player is in range
        {
            Vector3 target = Player.transform.position - transform.position; //make a target vector for path between the missile and the player
            targetAngle= Mathf.Atan2(target.y,target.x) * Mathf.Rad2Deg; //determine the angle of the target vector

            if (transform.eulerAngles.z > targetAngle) //if the angle of the missile is greater than the target angle
            {
                transform.Rotate(0, 0, angularSpeed * Time.deltaTime); //rotate at the angular speed
            }
            if (transform.eulerAngles.z < targetAngle) //if the angle of the missile is less than the target angle
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z); //make the missile go
                                                                                                                                //straight towards player?
            }


        }
    }
}
