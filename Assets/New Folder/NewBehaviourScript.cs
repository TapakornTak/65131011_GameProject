using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;

            StartCoroutine(MovePlayerSmoothly(targetPosition));
        }
    }

    IEnumerator MovePlayerSmoothly(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        float duration = distance / moveSpeed;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //// ให้ตำแหน่งสุดท้ายเป็นตำแหน่งที่ถูกปรับให้แน่นอน
        //transform.position = targetPosition;
    }
}
