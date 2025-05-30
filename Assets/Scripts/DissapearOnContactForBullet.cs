using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisappearOnContactForBullet : MonoBehaviour
{
    float lifeTimer = 0.83f; //��������� ��� ������ �������� �� �����
    public GameObject explosionPrefab;
   
    
    void OnTriggerEnter2D(Collider2D other)
    {

        // ���������, ������������� �� ������, � ������� ��������� ������������, ������������� �������
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet") // ���������, ��� � ������� ������ ���� ��� "Player"
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // ���������� ���� ������
        }
    }
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0) { Destroy(gameObject); }

    }
}
