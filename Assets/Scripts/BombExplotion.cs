using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Здесь вы можете проверить тэг объекта, чтобы убедиться, что это объект, который должен наносить урон
        if (other.gameObject.tag == "Player") 
            // Предположим, что объект, наносящий урон, имеет тэг "DamageSource"
        {
            Invoke("Explode", 0.2f); // Наносим урон бомбе, количество урона можно изменить
        }
        if (other.gameObject.tag == "PlayerBullet")
        {
            Invoke("Explode", 0.2f);
        }
    }
    // Начальное количество здоровья бомбы
    public GameObject explosionPrefab; // Префаб спрайта взрыва
    private void Update()
    {
        // Проверка координаты по оси Y
        if (transform.position.y <= -7.6f)
        {
            Explode();
        }
    }
    

    // Метод для нанесения урона бомбе
   
    // Метод для взрыва
    private void Explode()
    {
        // Создаем спрайт взрыва на месте бомбы
        GameObject exp = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exp, 0.2f);
        // Уничтожаем объект бомбы
        Destroy(gameObject);
    }

}
