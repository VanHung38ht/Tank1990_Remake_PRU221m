using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }*/
        if (collision.gameObject.tag == "block")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "rock")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "king")
        {
            Destroy(gameObject) ;
        }
    }
}
