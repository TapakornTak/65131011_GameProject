using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLook : MonoBehaviour
{
    public KeyCode killButton = KeyCode.Space;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);
    }

    void Update()
    {
        if (Input.GetKeyDown(killButton))
        {
            TestCollision();
        }
    }


    public void TestCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.25f);
        foreach (Collider2D Col in colliders)
        {
            Debug.Log("Obj : " + Col.gameObject.tag);

            RemoveEnemies();
        }
    }

    void RemoveEnemies()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, 0.25f);

        foreach (Collider2D enemyCollider in enemyColliders)
        {
            if (enemyCollider.CompareTag("enamy"))
            {
                Destroy(enemyCollider.gameObject);
            }
        }
    }
}
