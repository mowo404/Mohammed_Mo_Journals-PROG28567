using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform PlayerTransform;
    float distance;
    float DistanceNear = 2f;


    void Update()
    {
        //calculating the distance between player and enemy 
        distance = Vector3.Distance(PlayerTransform.position, transform.position);
        //if the distance is nearby specifically around 2F then execute Teleport method
        if (distance <= DistanceNear)
        {
            Teleport();
        }
        else
        {
            //the position stays unchanged
            transform.position = transform.position;
        }
    }

    void Teleport()
    {

        //Here, I'm creating a new vector for all the points on the Camera using Screen.width and height and Random.Range. This allows my enemy to teleport anywhere in the bounds of camera.
        Vector3 cameraPoint = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0);
        //We have to convert Camera to World view as well to ensure proper positioning
        cameraPoint = Camera.main.ScreenToWorldPoint(cameraPoint);
        //For some reason, enemy's z position turns to -10 (probably from the camera) so we have to hardcode our z position to be 0 like the player.
        cameraPoint.z = 0f;

        //change enemy position to the teleport randomly away from player at any point in the screen
        transform.position = cameraPoint;
    }
}