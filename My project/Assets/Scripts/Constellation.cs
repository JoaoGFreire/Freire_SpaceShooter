using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars2 : MonoBehaviour
{
    public List<Transform> starTransforms2;
    public float drawingTime2;

    private int currentStarIndex = 0;
    private float currentTimeDrawing = 0f;

    // Update is called once per frame
    void Update()
    {
        currentTimeDrawing += Time.deltaTime;
        float ratio = currentTimeDrawing / drawingTime2;

        Vector3 directionToTarget = starTransforms2[currentStarIndex + 1].position - starTransforms2[currentStarIndex].position;

        Vector3 startPoint = starTransforms2[currentStarIndex].position;
        Vector3 endPoint = directionToTarget * ratio;

        Vector3 currentPosition = Vector3.Lerp(startPoint, endPoint, ratio);
        Debug.DrawLine(startPoint, endPoint, Color.white);

        if(ratio >= 1)
        {
            currentStarIndex++;
            currentTimeDrawing = 0f;
            if((currentStarIndex  +1 )>= starTransforms2.Count)
            {
                currentStarIndex = 0;
            }
        }

    }
}
