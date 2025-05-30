using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBagSpawner : MonoBehaviour
{
    public GameObject healBagPrefab; // ������ �����
    public float spawnInterval = 2f; // �������� ����� ��������
    public float spawnWidth = 16f; // ������ ���� ������

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnHealBag();
            timer = spawnInterval; // ����� �������
        }
    }

    void SpawnHealBag()
    {
        float spawnX = Random.Range(-spawnWidth / 2, spawnWidth / 2); // ��������� ������� X
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0);

        Instantiate(healBagPrefab, spawnPosition, Quaternion.identity);
    }
}

