using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 1f;
    private Vector3 bulletPos;
    private Vector3 bounds;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        
       //move the bullet position using bulletSpeed * Time by the y componenet
        transform.position += new Vector3(0, bulletSpeed, 0) * Time.deltaTime;
        transform.position.Normalize();

        //bounds includes the whole screen for the bullet 
        Vector3 bounds = new Vector3(Screen.width, Screen.height);
        bounds = Camera.main.ScreenToWorldPoint(bounds);
        if (transform.position.y > bounds.y)
        {
            Destroy(gameObject);
        }
        
    }

    public void OnHit(Collider2D col)
    {
        //using the tags we made earlier col.tag checks for the tags assigned to the prefabs to see if the enemy tag collided with the bullet tag
        if (col.tag == "EnemyTag")
        {
            //destroy the bullet if it lands on enemy for a more realistic shot without this code the bullet would keep going up after killing the enemy...
            Destroy(gameObject);
            Debug.Log("Hit");
        }
    }
}
