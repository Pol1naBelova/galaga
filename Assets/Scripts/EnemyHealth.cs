using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // ������������ �������� �����
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
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // ���������� ������ �����
        GameManager.score++;
        // ����� ����� �������� ������ ��� �������� ������, ����� � �.�.
    }
}
