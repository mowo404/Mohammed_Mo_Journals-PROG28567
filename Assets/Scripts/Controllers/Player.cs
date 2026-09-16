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
        }
        
    }

    void SpawnBombAtOffest(Vector3 inOffset)
    {
        Instantiate(bombPrefab, transform.position + inOffset, Quaternion.identity);
    }
}
