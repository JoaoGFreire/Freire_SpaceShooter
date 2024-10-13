using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    // Start is called before the first frame update
    public float BoostRadius;
    public float sides;
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
    public void drawRange()
    {
        float n = 360 / sides;
        Vector3 offset = new Vector3(BoostRadius, 0, 0);
        Vector3 Point = transform.position + offset;
        for(int i = 0; i <= sides; i++)
        {
            float angle = (n * i) * Mathf.Deg2Rad;
            Vector3 nextPoint = transform.position + new Vector3(Mathf.Cos(angle) * BoostRadius, Mathf.Sin(angle) * BoostRadius, 0f);

            Debug.DrawLine(Point,nextPoint,Color.yellow);
            Point = nextPoint;

        }
    }

    public void SpeedChange()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= BoostRadius)
        {
            Player.SendMessage("IncreaseSpeed");
        }
        else
        {
            Player.SendMessage("DecreaseSpeed");
        }
    }
}
