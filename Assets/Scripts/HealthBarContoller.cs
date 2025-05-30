using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthBarImage;  // Ссылка на компонент Image
    public Sprite[] healthBarSprites;  // Массив спрайтов для каждого уровня здоровья
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
        player.currentHealth = Mathf.Clamp(health, 0, player.maxHealth);  // Ограничиваем значение здоровья от 0 до maxHealth
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

