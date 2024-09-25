using Codice.Client.BaseCommands.Merge;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class Exercise1 : MonoBehaviour
{
    List<float> angles = new List<float>() { 0f, 45f, 90f, 135f, 180f,225f, 270f,315f, 360f };
    //float x = 36f;
    private int currentAngleIndex = 0;
    private float timeSinceLastUpdate = 0f;
    public float updateFrequency;
    public float radius = 1f;
    public Vector3 StartP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //while(x <= 360)
        //{
        //    angles.Add(x);
        //    x += 36f;
        //}
        //float = Mathf.Cos(angles < 0 >);

        Vector3 startingPoint = Vector3.zero + StartP;
        
        float currentAngle = angles[currentAngleIndex];
        float endPointX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float endPointY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        Vector3 endingPoint = (new Vector3(endPointX, endPointY))*radius + StartP;
        Debug.DrawLine(startingPoint, endingPoint, Color.red);

        timeSinceLastUpdate += Time.deltaTime;



        if (timeSinceLastUpdate > updateFrequency)
        {
            timeSinceLastUpdate = 0;
            currentAngleIndex++;
            if(currentAngleIndex >= angles.Count)
            {
                currentAngleIndex = 0;
            }
        }
    }
}
