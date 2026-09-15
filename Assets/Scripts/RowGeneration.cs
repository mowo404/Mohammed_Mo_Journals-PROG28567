using UnityEngine;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    public bool drawline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(drawline == true)
        {
            Debug.DrawLine(new Vector2(10f, 10f), new Vector2(-10f, 10f));
            Debug.DrawLine(new Vector2(-10f, 10f), new Vector2(-10f, -10f));
            Debug.DrawLine(new Vector2(-10f, -10f), new Vector2(10f, -10f));
            Debug.DrawLine(new Vector2(10f, -10f), new Vector2(10f, 10f));

            Debug.Log("False");

            return;

        }
        
    }

    public void OnButton() 
    {
        drawline = true;
        Debug.Log("Button Pressed!");

    }
}
