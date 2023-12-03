using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    private string Look;

    void Update()
    {
        TestCollision();
    }

    public void TestCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.25f);
        foreach (Collider2D Col in colliders)
        {
            Debug.Log("ploy : "+Col.gameObject.tag);
            Look = Col.gameObject.tag;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);
    }
}
