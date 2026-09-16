using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Pipeline : MonoBehaviour
{
    public Vector2 mousePosition;
    public Vector2 worldMouse;
    public Vector2 mouseHeld;
    public Vector2 mouseHeld2;
    public float timer = 0f;
    public float timestop = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        mousePosition = Mouse.current.position.ReadValue();
        worldMouse = Camera.main.ScreenToWorldPoint(mousePosition);

        while (Mouse.current.leftButton.isPressed) 
        {
            mouseHeld = mousePosition;

        }

        if (timer >= 0.1f && Mouse.current.leftButton.isPressed)
        {
            Debug.DrawLine(mouseHeld - new Vector2(1f, 1f), worldMouse - new Vector2(-1f, 1f));
            mouseHeld2 = mousePosition;
            timer = 0f;
        }

        if (timer >= 0.2f && Mouse.current.leftButton.isPressed)
        {
            Debug.DrawLine(mouseHeld2 - new Vector2(1f, 1f), worldMouse - new Vector2(-1f, 1f));
            timer = 0f;
        }
        //it feels too quick
    }
}