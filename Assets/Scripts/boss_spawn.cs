using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_spawn : MonoBehaviour
{
    public GameObject bossPrefab;
    private bool isSpawned = false;

    void Update()
    {
        if (GameManager.score % 15 == 0 && GameManager.score != 0 && isSpawned != true) 
        {
            SpawnBoss();
            isSpawned = true;
        }
    }

    void SpawnBoss()
    {
       
        GameObject boss = Instantiate(bossPrefab, transform.position, Quaternion.identity);
    }
}    
