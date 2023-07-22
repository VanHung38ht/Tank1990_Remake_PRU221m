using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static intruct;

public class SetUpInMap1 : MonoBehaviour
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
        
        tank.transform.position = new Vector3(1.6f, -4.6f, 0);

        Time.timeScale = 1;

        UndyingAni.SetActive(true);

        Instantiate(enemy, new Vector3(-4.8f, 2.08f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(1.28f, -1.12f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(3.84f, 2.08f, 0), Quaternion.identity);
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
                randomPosition = UnityEngine.Random.Range(0, 3);
                countTime1 = 0;

                if (randomPosition == 0)
                {
                    Instantiate(enemy, new Vector3(-4.8f, 2.08f, 0), Quaternion.identity);
                }
                else if (randomPosition == 1)
                {
                    Instantiate(enemy, new Vector3(1.28f, -1.12f, 0), Quaternion.identity);
                }
                else if (randomPosition == 2)
                {
                    Instantiate(enemy, new Vector3(3.84f, 2.08f, 0), Quaternion.identity);
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
                Instantiate(enemy, new Vector3(-3f, 4.3f, 0), Quaternion.identity);
            }
            else if (randomPosition == 1)
            {
                Instantiate(enemy, new Vector3(-0.01f, 4.3f, 0), Quaternion.identity);
            }
            else if (randomPosition == 2)
            {
                Instantiate(enemy, new Vector3(3.8f, 2.3f, 0), Quaternion.identity);
            }
        }
    }
}