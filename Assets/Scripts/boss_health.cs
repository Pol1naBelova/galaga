using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    public int maxHealth = 20; // ������������ �������� �����
    private int currentHealth; // ������� �������� �����
    public GameObject explosionPrefab;


    void Start()
    {
        currentHealth = maxHealth; // ��������� �������� ��� �������� �����
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        // ���������, ������������� �� ������, � ������� ��������� ������������, ������������� �������
        if (other.gameObject.tag == "PlayerBullet") // ���������, ��� � ������� ������ ���� ��� "Player"
        {
            TakeDamage(1);

        }
        if (other.gameObject.tag == "Player")
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ��������� �������� �� �������� ����������� �����
        if (currentHealth <= 0)
        {
            Die(); // ������� ������, ���� �������� ��������� �� 0 ��� ����
        }
    }

    private void Die()
    {
        Destroy(gameObject); // ���������� ������ �����
        GameManager.score++;
        // ����� ����� �������� ������ ��� �������� ������, ����� � �.�.
    }
}
