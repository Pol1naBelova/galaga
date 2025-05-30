using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MommySpaceship : MonoBehaviour
{
    public int maxHealth = 5; // ������������ �������� �����
    public int currentHealth; // ������� �������� �����


    void Start()
    {
        currentHealth = maxHealth; // ��������� �������� ��� �������� �����
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        // ���������, ������������� �� ������, � ������� ��������� ������������, ������������� �������
        if (other.CompareTag("Enemy") ||  (other.CompareTag("EnemyBullet"))) // ���������, ��� � ������� ������ ���� ��� "Player"
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
        SceneManager.LoadScene("GameOver");
        // ����� ����� �������� ������ ��� �������� ������, ����� � �.�.
    }
} 
