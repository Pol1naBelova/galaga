using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthBarImage;  // ������ �� ��������� Image
    public Sprite[] healthBarSprites;  // ������ �������� ��� ������� ������ ��������
    public PlayerHealth player;

    //private int maxHealth = 5;
    //private int currentHealth;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        UpdateHealthBar();
    }

    public void SetHealth(int health)
    {
        player.currentHealth = Mathf.Clamp(health, 0, player.maxHealth);  // ������������ �������� �������� �� 0 �� maxHealth
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (player.currentHealth >= 0 && player.currentHealth < healthBarSprites.Length)
        {
            healthBarImage.sprite = healthBarSprites[player.currentHealth];
        }
    }
}

