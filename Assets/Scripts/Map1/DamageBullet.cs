using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : MonoBehaviour
{
    HealthPlayer healthPlayer;
    public int damage;
    int map;

    public void Start()
    {
        damage = 2;
        healthPlayer = FindObjectOfType<HealthPlayer>();
        ChooseMap chooseMap = FindObjectOfType<ChooseMap>();
        map = chooseMap.map;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if ( map == 1)
            {
                healthPlayer.TakeDamage(damage);

            }
            Destroy(gameObject);
        }
    }
}
