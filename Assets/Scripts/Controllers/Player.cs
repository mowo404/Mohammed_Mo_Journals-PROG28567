using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
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
}
