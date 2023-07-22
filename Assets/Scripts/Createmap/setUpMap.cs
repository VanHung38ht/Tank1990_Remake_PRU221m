using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpMap : MonoBehaviour
{
    public GameObject tank, UndyingAni, enemy;
    float countTime = 0, countTime1 = 0;
    int randomPosition, a = 1, quantity = 4;
    GameObject[] enemyCount;
    [SerializeField] private AudioSource StartSound;

    public static class undying
    {
        public static bool isundying = true;
        public static bool isPlaying = true;
    }

    public void setUp()
    {
        tank = GameObject.FindGameObjectWithTag("Player");

        tank.transform.position = new Vector3(-1.28f, -4.16f, 0);

        Time.timeScale = 1;

        UndyingAni.SetActive(true);

        Instantiate(enemy, new Vector3 (-5.12f, 3.84f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(-2.88f, 2.88f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(5.12f, 3.84f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(2.88f, 2.88f, 0), Quaternion.identity);
        a = 0;

        undying.isPlaying = true;
        StartSound.Play();
    }

    private void Update()
    {
        countTime += Time.deltaTime;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");

        if ( (enemyCount.Length < quantity && a == 0))
        {
            countTime1 += Time.deltaTime;

            if (countTime1 > 1)
            {
                randomPosition = UnityEngine.Random.Range(0, 4);
                countTime1 = 0;

                if (randomPosition == 0)
                {
                    Instantiate(enemy, new Vector3(-5.12f, 3.84f, 0), Quaternion.identity);
                }
                else if (randomPosition == 1)
                {
                    Instantiate(enemy, new Vector3(-2.88f, 2.88f, 0), Quaternion.identity);
                }
                else if (randomPosition == 2)
                {
                    Instantiate(enemy, new Vector3(5.12f, 3.84f, 0), Quaternion.identity);
                }
                else if (randomPosition == 3)
                {
                    Instantiate(enemy, new Vector3(2.88f, 2.88f, 0), Quaternion.identity);
                }
            }
        }

        if ((countTime > 10 && a == 0))
        {
            randomPosition = UnityEngine.Random.Range(0, 4);

            countTime = 0;
            quantity += 1;

            if (randomPosition == 0)
            {
                Instantiate(enemy, new Vector3(-5.12f, 3.84f, 0), Quaternion.identity);
            }
            else if (randomPosition == 1)
            {
                Instantiate(enemy, new Vector3(-2.88f, 2.88f, 0), Quaternion.identity);
            }
            else if (randomPosition == 2)
            {
                Instantiate(enemy, new Vector3(5.12f, 3.84f, 0), Quaternion.identity);
            }
            else if (randomPosition == 3)
            {
                Instantiate(enemy, new Vector3(2.88f, 2.88f, 0), Quaternion.identity);
            }
        }
    }
}
