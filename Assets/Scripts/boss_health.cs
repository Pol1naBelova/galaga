using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    public int maxHealth = 20; // Максимальное здоровье врага
    private int currentHealth; // Текущее здоровье врага
    public GameObject explosionPrefab;


    void Start()
    {
        currentHealth = maxHealth; // Начальное здоровье при создании врага
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        // Проверяем, соответствует ли объект, с которым произошло столкновение, определенному условию
        if (other.gameObject.tag == "PlayerBullet") // Убедитесь, что у объекта игрока есть тег "Player"
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
        currentHealth -= damage; // Уменьшаем здоровье на величину полученного урона
        if (currentHealth <= 0)
        {
            Die(); // Функция смерти, если здоровье опустится до 0 или ниже
        }
    }

    private void Die()
    {
        Destroy(gameObject); // Уничтожаем объект врага
        GameManager.score++;
        // Здесь можно добавить логику для анимации смерти, очков и т.д.
    }
}
