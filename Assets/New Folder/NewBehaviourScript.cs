using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float minX = -1.7f; 
    public float maxX = 1.7f; 
    public float minY = -0.9f; 
    public float maxY = 0.9f; 

   
    void Update()
    {
        MovePlayerWithMouse();
    }

    void MovePlayerWithMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(clampedX, clampedY, 0f), moveSpeed * Time.deltaTime);
    }
}
