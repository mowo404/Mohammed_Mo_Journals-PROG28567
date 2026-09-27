using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public float moveSpeed = 1.0f;
    public float maxSpeed = 5f;
    public float accelarationTime = 2f;

    //variable to calculate our actual accelaration so it does not neeed to be public 
    private float acceleration = 5f;
    private float deacceleration = 10f;
    //this variable tracks our velocity to keep within update
    private Vector2 velocity;
    private Vector2 stopMovement;
    void Start()
    {
        //since we're in start our accelaration only needs to be calculated one time
        acceleration = maxSpeed / accelarationTime; // a = V/T
    }
    // Update is called once per frame
    void Update()
    {


        if (Keyboard.current.bKey.isPressed)
        {
            SpawnBombAtOffest(Vector3.up);
            //run output of vector
            Normalized();
        }

        //when m is pressed run the jump method
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            //run jump method to warp
            Jump();
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(3, -0.5F);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            //inDistance value is 3 away from the ship
            SpawnBombOnRandomCorner(3);

        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DetectAsetroids(10f,asteroidTransforms);
        }

        if(Keyboard.current.wKey.isPressed) 
        {
            //accelerating 1 unit up
            velocity += acceleration * Time.deltaTime * Vector2.up;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            //accelerating 1 unit to the left
            velocity += acceleration * Time.deltaTime * Vector2.left;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            //accelerating 1 unit down
            velocity += acceleration * Time.deltaTime * Vector2.down;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            //accelerating 1 unit to the right
            velocity += acceleration * Time.deltaTime * Vector2.right;
        }

        //take the value of velocity and our maxSpeed to clamp the velocity vectors to a specific contained value
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
        //adding velocity (making sure its vector 3 because we cant convert vector 2 to vector 3) to our transform position allowing to move
        transform.position += (Vector3)velocity * Time.deltaTime;

        //if WASD are let go then start deaccleration...
        if (!Keyboard.current.wKey.isPressed && !Keyboard.current.sKey.isPressed && !Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
        {
            PlayerMovement();
        }

        

    }

    #region SpawnBombAtOffest
    void SpawnBombAtOffest(Vector3 inOffset)
    {
        Instantiate(bombPrefab, transform.position + inOffset, Quaternion.identity);
    }
    #endregion


    void Normalized()
    {
        Vector2 playerpos = new Vector2(3, 4);
        playerpos.Normalize();
        Debug.Log(playerpos);
    }

    //method for jump feature
    void Jump()
    {

        //if transform.position is greater than or equal to enemey transform position then warp the player near the enemy
        if (transform.position.y >= enemyTransform.position.y && transform.position.x >= enemyTransform.position.x)
        {
            transform.position = enemyTransform.position - new Vector3(1, 1, 0);
        }
        else
        {
            //transform position stays unchanged if not nearby
            transform.position = transform.position;
        }
    }

    void SpawnBombTrail(int numberOfTrailBombs, float BombTrailSpacing)
    {
        //for loop to repeat a series of bomb spawning using the numberTrail variable for the parameters, loop until 3 bombs are spawned then stop looping.
        for (numberOfTrailBombs = 0; numberOfTrailBombs < 3; numberOfTrailBombs++)
        {
            //for spacing between the bombs I added a new vector to the instantiate transform and added the spacing * numberOfbombs
            Instantiate(bombPrefab, transform.position + new Vector3(0, BombTrailSpacing * numberOfTrailBombs - 0.7F, 0), Quaternion.identity);

        }

    }

    void SpawnBombOnRandomCorner(float inDistance)
    {
        //have to make sure its an interger rather than a float so the numbers are exact
        int random = Random.Range(1, 5);
        Debug.Log(random);


        //corner 1.. if random lands on 1 then draw it in this corner
        if (random == 1)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(-inDistance, inDistance, 0)), Quaternion.identity);
        }
        //corner 2.. if random lands on 2 then draw it in this corner
        if (random == 2)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(inDistance, -inDistance, 0)), Quaternion.identity);
        }
        //corner 3.. if random lands on 3 then draw it in this corner
        if (random == 3)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(-inDistance, -inDistance, 0)), Quaternion.identity);
        }
        //corner 4.. if random lands on 4 then draw it in this corner
        if (random == 4)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(inDistance, inDistance, 0)), Quaternion.identity);
        }

    }

    public void DetectAsetroids(float inMaxRange, List<Transform> inAesteroids)
    {

        for (int i = 0; i < inAesteroids.Count; i++)
        {
            //check each transform position in the list 
            Transform currentAestroid = inAesteroids[i].transform;

            float distance = Vector3.Distance(currentAestroid.position, transform.position);
            if (distance >= inMaxRange)
            {
                Debug.DrawLine(transform.position, currentAestroid.position, Color.green);
            }


        }
    }

    void PlayerMovement()
    {
        //add a way to limit MaxSpeed
        

            stopMovement = velocity.normalized;
            
            if(velocity != Vector2.zero)
            {
                velocity -=  Time.deltaTime * deacceleration * stopMovement;
            }
        

    }
}
