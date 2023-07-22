using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class shot : MonoBehaviour
{
    GameControll coin;
    int map;

    private void Start()
    {
        coin = FindObjectOfType<GameControll>();
        ChooseMap chooseMap = FindObjectOfType<ChooseMap>();

        map = chooseMap.map;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            if (map == 1)
            {
                coin.incrementSscore();
            }
        }
        if (collision.gameObject.tag == "block")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "rock")
        {
            Destroy(gameObject);
        }
    }
}
