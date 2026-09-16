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

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {

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

    void Jump()
    {
        Vector2 enemypos = enemyTransform.position;
        //calculating the distance using vector substraction.
        Vector2 direction = enemyTransform.position - transform.position;
    }
}
