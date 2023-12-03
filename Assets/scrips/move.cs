using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour   , IPointerDownHandler, IBeginDragHandler , IDragHandler , IEndDragHandler
{
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 1f; 

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        addPhysics2DRaycaster();
    }

    void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        spriteRenderer.color = Color.blue;

        //transform.position += new Vector3(eventData.delta.x * Time.deltaTime, eventData.delta.y * Time.deltaTime);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldmousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldmousePosition.z = 0f;

        transform.position = Vector3.MoveTowards(transform.position, worldmousePosition, moveSpeed * Time.deltaTime);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        spriteRenderer.color = Color.white;
        Debug.Log("Drag Ended");
    }

}
