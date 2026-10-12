using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitSpeed = 2F;
    float stepAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(2F, orbitSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        //increasing base angle each frame per second and by our set speed
        stepAngle += Time.deltaTime * speed;

        //converting our angle from degrees to radians
        float baseAngle = stepAngle * Mathf.Deg2Rad;

        //variables to find both the x and y position of the point on the unit circle
        float xPos = Mathf.Cos(baseAngle) * radius;
        float yPos = Mathf.Sin(baseAngle) * radius;

        //create a new variable that subs in values for our x and y points
        Vector3 position = new Vector3(xPos, yPos, 0);

        //change the position of the moon based on the angles on the unit circle in turn rotating around in a 360 motion and being offset by the position of the planet
        transform.position = target.position + position; 

       

    }
}
