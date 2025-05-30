using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public bool isBossAlive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.score % 10 == 0 && GameManager.score != 0 && isBossAlive == false)
        {
            SpawnBoss();
            isBossAlive = true;
        }
    }
    void SpawnBoss()
    {
        float spawnX = -3f;
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0);

        Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
    }
}
