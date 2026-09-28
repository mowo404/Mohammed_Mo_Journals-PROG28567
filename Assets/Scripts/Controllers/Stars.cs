using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public float Timer = 0;
    private Vector3 currentPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    float starDistance;
    float starSpace = 2f;

    // Update is called once per frame
    void Update()
    {

        DrawConstellation();
    }

    public void DrawConstellation()
    {
        for (int i = 0; i < starTransforms.Count; i++)
        {
            startPosition = starTransforms[i].position;
            endPosition = starTransforms[i + 1].position;
            currentPosition = startPosition + endPosition;
            starDistance = Vector3.Distance(startPosition, endPosition);

            
            Debug.DrawLine(startPosition, endPosition, Color.magenta);
            
           
            
            



        }

    }
}
