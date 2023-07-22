using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f;

    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnAnEnemy()
    {

        Vector2 spawnPos = GameObject.Find("BaseEnemy").transform.position;
        Vector2 spawnPos2 = GameObject.Find("BaseEnemy1").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        spawnPos2 += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
     
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos2, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
