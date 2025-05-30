using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MommySpaceship : MonoBehaviour
{
    public int maxHealth = 5; // Максимальное здоровье врага
    public int currentHealth; // Текущее здоровье врага


    void Start()
    {
        currentHealth = maxHealth; // Начальное здоровье при создании врага
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        // Проверяем, соответствует ли объект, с которым произошло столкновение, определенному условию
        if (other.CompareTag("Enemy") ||  (other.CompareTag("EnemyBullet"))) // Убедитесь, что у объекта игрока есть тег "Player"
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
        SceneManager.LoadScene("GameOver");
        // Здесь можно добавить логику для анимации смерти, очков и т.д.
    }
} 
