using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance = 1f;
    public float maxFloatDistance;
    public Vector3 randomPoint;
    float distance;
   

    // Start is called before the first frame update
    void Start()
    {
        //find a random point at the first frame
        randomPoint = new Vector3(Random.Range(0, maxFloatDistance), Random.Range(0, maxFloatDistance), 0);
    }

    // Update is called once per frame
    void Update()
    { 
        AesteroidMovement();
    }

    public void AesteroidMovement()
    {
        //reterieve the direction of the aesteriods
        Vector3 Direction = (randomPoint - transform.position).normalized;
        //the movement of the aesteriod based on moveSpeed and direction
        transform.position += Time.deltaTime * moveSpeed * Direction;
        //calculating the distance between both aesteroid position and our randomPoint
        distance = Vector3.Distance(transform.position, randomPoint);
        
        if(distance <= arrivalDistance)
        {
            //find a new point when the aesteriod reaches its destination(random point)
            randomPoint = new Vector3(Random.Range(0, maxFloatDistance), Random.Range(0, maxFloatDistance), 0);
        }
        



    }
}
