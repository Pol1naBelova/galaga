using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisappearOnContactForBullet : MonoBehaviour
{
    float lifeTimer = 0.83f; //Пропадает как только вылетает за экран
    public GameObject explosionPrefab;
   
    
    void OnTriggerEnter2D(Collider2D other)
    {

        // Проверяем, соответствует ли объект, с которым произошло столкновение, определенному условию
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet") // Убедитесь, что у объекта игрока есть тег "Player"
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // Уничтожает этот объект
        }
    }
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0) { Destroy(gameObject); }

    }
}
