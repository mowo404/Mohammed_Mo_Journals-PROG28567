using NUnit.Framework.Internal;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    //variable that randomly selects a number from 1-4 for the corners 
    public float random = Random.Range(1f, 4f);




    // Update is called once per frame
    void Update()
    {

        if(Keyboard.current.bKey.wasPressedThisFrame) 
        {
            SpawnBombAtOffest(Vector3.up);
            //run output of vector
            Normalized();
        }

        //when m is pressed run the jump method
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //run jump method to warp
            Jump();
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(3,-0.5F);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            
           if(random <= 4)
            {
                SpawnBombOnRandomCorner(5);
            }
            
        }



    }

    void SpawnBombAtOffest(Vector3 inOffset)
    {
        Instantiate(bombPrefab, transform.position + inOffset, Quaternion.identity);
    }

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
            transform.position = enemyTransform.position - transform.position;
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
        for(numberOfTrailBombs = 0; numberOfTrailBombs < 3; numberOfTrailBombs++)
        {
            //for spacing between the bombs I added a new vector to the instantiate transform and added the spacing * numberOfbombs
            Instantiate(bombPrefab, transform.position + new Vector3(0, BombTrailSpacing * numberOfTrailBombs - 0.7F, 0), Quaternion.identity);
            
        }
        
    }

    void SpawnBombOnRandomCorner(float inDistance)
    {
        //corner 1 
        if(random == 1)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(-inDistance, inDistance, 0)), Quaternion.identity);
        }
        //corner 2
        if (random == 2)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(-inDistance, inDistance, 0)), Quaternion.identity);
        }
        //corner 3
        if (random == 3)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(inDistance, -inDistance, 0)), Quaternion.identity);
        }
        //corner 4
        if (random == 4)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(-inDistance, -inDistance, 0)), Quaternion.identity);
        }
        //corner 5
        if (random == 5)
        {
            Instantiate(bombPrefab, (transform.position + new Vector3(inDistance, inDistance, 0)), Quaternion.identity);
        }


        
    }
}
