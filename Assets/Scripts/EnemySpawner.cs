using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; //��� ����� ��������
    public float spawnInterval = 2f; // �����
    public float spawnWidth = 16f; // ������ ���� ������
    public GameObject enemySpawner;
    BossSpawner bossSpawner;

    private float timer;

    void Start()
    {
        bossSpawner = GameObject.Find("BossSpawner").GetComponent<BossSpawner>();
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnInterval; // ����� �������
        }
        if (bossSpawner.isBossAlive == true)
        {
            enemySpawner.SetActive(false);
        }
    }

    void SpawnEnemy()
    {
        float spawnX = Random.Range(-spawnWidth / 2, spawnWidth / 2); // ��������� ������� X
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
