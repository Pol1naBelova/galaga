using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject shield;
    GameObject spawnedShield;
    public static int score;
    bool isShieldOn;
    void Update()
    {
        if (score % 10 == 0 && score != 0 && isShieldOn == false)
        {
            SpawnShield();
            isShieldOn = true;
        }
    }
    void SpawnShield()
    {
        float spawnX = 0.42f;
        float spawnY = -9.8f;
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        spawnedShield = Instantiate(shield, spawnPosition, Quaternion.identity);
    }
}
