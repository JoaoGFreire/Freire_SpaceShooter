using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    // Start is called before the first frame update
    public float BoostRadius; //effective range of the boost 
    public float sides; // number of sides for the boost pad radius circle
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drawRange();
        SpeedChange();
    }
    //draws the effective range of the boostpad
    public void drawRange()
    {
        float n = 360 / sides; 
        Vector3 offset = new Vector3(BoostRadius, 0, 0);
        Vector3 Point = transform.position + offset;
        for(int i = 0; i <= sides; i++)
        {
            float angle = (n * i) * Mathf.Deg2Rad; //new angle for each point in the circle
            Vector3 nextPoint = transform.position + new Vector3(Mathf.Cos(angle) * BoostRadius, Mathf.Sin(angle) * BoostRadius, 0f); //cos and sin of angle to
                                                                                                                                      //determine x and y positions

            Debug.DrawLine(Point,nextPoint,Color.yellow);
            Point = nextPoint;

        }
    }

    public void SpeedChange()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= BoostRadius) //checks if the player is
                                                                                            //inside the radius of the boost pad
        { //if it is, tell player to increase speed
            Player.SendMessage("IncreaseSpeed");
        }
        else //if it isnt, tell player to decrease speed (better term would actually be default speed)
        {
            Player.SendMessage("DecreaseSpeed");
        }
    }
}
