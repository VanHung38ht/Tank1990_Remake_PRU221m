using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "bulletEnemy")
        {
            Destroy(gameObject);
        }
    }
}
