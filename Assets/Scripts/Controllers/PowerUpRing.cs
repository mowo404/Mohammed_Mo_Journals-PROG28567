using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpRing : MonoBehaviour
{
    public Transform playerTransform;
    public float ringSpeed = 2F;
    float stepAngle;
    public GameObject Powerprefab;
    private List<GameObject> powerUps = new List<GameObject>();
    int maxLimit = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {

            SpawnPowerUp();
        }
        RingMotion(2F, ringSpeed, playerTransform);
    }

    public void RingMotion(float radius, float speed, Transform target)
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

    public void SpawnPowerUp()
    {
        //if the powerUp count is less than our max limit then spawn in our powerUpPrefab and keep counting/adding to the list until this statement is false
        if(powerUps.Count < maxLimit)
        {
            GameObject spawn = Instantiate(Powerprefab, playerTransform.position, Quaternion.identity);
            powerUps.Add(spawn);
        }
    }
}
