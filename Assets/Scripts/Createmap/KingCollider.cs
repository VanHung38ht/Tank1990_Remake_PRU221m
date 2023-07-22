using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static intruct;

public class KingCollider : MonoBehaviour
{
    int a = 3;
    public GameObject Summary, close;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletEnemy"  || collision.gameObject.tag == "bullet")
        {
            a -= 1;

            if (a == 0)
            {
                Summary.SetActive(true);
                //intruct.GameStatus.isGameRunning = false;
                GameStatus.isTankPlay = false;
                Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Time.timeScale = 0;
                EventSystem.current.SetSelectedGameObject(null);
                // Choose a new selected object
                EventSystem.current.SetSelectedGameObject(close);
            }
        }
    }
}
