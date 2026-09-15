using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector2 mousePosition;
    public Vector2 worldMouse;
    public Vector2 transparentSquare;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        worldMouse = Camera.main.ScreenToWorldPoint(mousePosition);

        //transparent square position is the same position as mouse
        transparentSquare = worldMouse;

        if (Mouse.current.leftButton.isPressed)
        {
            //drawing all 4 sides of the square
            Debug.DrawLine(worldMouse - new Vector2(1f, 1f), worldMouse - new Vector2(-1f, 1f));
            Debug.DrawLine(worldMouse - new Vector2(-1f, 1f), worldMouse - new Vector2(-1f, -1f));
            Debug.DrawLine(worldMouse - new Vector2(-1f, -1f), worldMouse - new Vector2(1f, -1f));
            Debug.DrawLine(worldMouse - new Vector2(1f, -1f), worldMouse - new Vector2(1f, 1f));

        }
        else 
        {
            //transparent square drawn at all times until mouse pressed
            Debug.DrawLine(worldMouse - new Vector2(1f, 1f), worldMouse - new Vector2(-1f, 1f), new Color(255f,255f,255f, 0.2f));
            Debug.DrawLine(worldMouse - new Vector2(-1f, 1f), worldMouse - new Vector2(-1f, -1f), new Color(255f, 255f, 255f, 0.2f));
            Debug.DrawLine(worldMouse - new Vector2(-1f, -1f), worldMouse - new Vector2(1f, -1f), new Color(255f, 255f, 255f, 0.2f));
            Debug.DrawLine(worldMouse - new Vector2(1f, -1f), worldMouse - new Vector2(1f, 1f), new Color(255f, 255f, 255f, 0.2f));
        }

        



    }
}
