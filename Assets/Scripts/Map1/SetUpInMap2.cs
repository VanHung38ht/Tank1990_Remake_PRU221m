using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static intruct;

public class SetUpInMap2 : MonoBehaviour
{
    public GameObject tank, UndyingAni, enemy;
    float countTime = 0, countTime1 = 0;
    int randomPosition, a = 1, quantity = 3;
    GameObject[] enemyCount;
    [SerializeField] private AudioSource StartEffect;


    public static class undying
    {
        public static bool isundying = true;
        public static bool isPlaying = true;
    }

    public void Start()
    {
        ChooseMap chooseMap = FindObjectOfType<ChooseMap>();
        GameStatus.isTankPlay = true;
        chooseMap.map = 1;
        tank = GameObject.FindGameObjectWithTag("Player");

        tank.transform.position = new Vector3(1.6f, -4.16f, 0);

        Time.timeScale = 1;

        UndyingAni.SetActive(true);

        Instantiate(enemy, new Vector3(-4.8f, 1.12f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(4.8f, 1.12f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(3.2f, 4f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(-3.2f, 4f, 0), Quaternion.identity);
        a = 0;

        undying.isPlaying = true;
        StartEffect.Play();
    }

    private void Update()
    {
        countTime += Time.deltaTime;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");

        if ((enemyCount.Length < quantity && a == 0))
        {
            countTime1 += Time.deltaTime;

            if (countTime1 > 1)
            {
                randomPosition = UnityEngine.Random.Range(0, 4);
                countTime1 = 0;

                if (randomPosition == 0)
                {
                    Instantiate(enemy, new Vector3(-4.8f, 1.12f, 0), Quaternion.identity);
                }
                else if (randomPosition == 1)
                {
                    Instantiate(enemy, new Vector3(4.8f, 1.12f, 0), Quaternion.identity);
                }
                else if (randomPosition == 2)
                {
                    Instantiate(enemy, new Vector3(3.2f, 4f, 0), Quaternion.identity);
                }
                else if (randomPosition == 3)
                {
                    Instantiate(enemy, new Vector3(-3.2f, 4f, 0), Quaternion.identity);
                }
            }
        }

        if ((countTime > 10 && a == 0))
        {
            randomPosition = UnityEngine.Random.Range(0, 3);

            countTime = 0;
            quantity += 1;

            if (randomPosition == 0)
            {
                Instantiate(enemy, new Vector3(-4.8f, 1.12f, 0), Quaternion.identity);
            }
            else if (randomPosition == 1)
            {
                Instantiate(enemy, new Vector3(4.8f, 1.12f, 0), Quaternion.identity);
            }
            else if (randomPosition == 2)
            {
                Instantiate(enemy, new Vector3(3.2f, 4f, 0), Quaternion.identity);
            }
            else if (randomPosition == 3)
            {
                Instantiate(enemy, new Vector3(-3.2f, 4f, 0), Quaternion.identity);
            }
        }
    }
}
