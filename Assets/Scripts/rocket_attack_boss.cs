using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_attack_boss : MonoBehaviour
{
    public GameObject rocketPrefab; // Префаб ракеты
    public Transform[] firePoints; // Массив точек, откуда будут вылетать ракеты
    public Transform target;
    private bool canShoot = true; // Флаг, показывающий, можно ли стрелять
    public float attackDuration;

    private void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootRockets());

        }
    }

    IEnumerator ShootRockets()
    {
        canShoot = false; // Запрещаем стрельбу

        foreach (Transform firePoint in firePoints)
        {
            ShootRocket(firePoint); // Стреляем ракетой из текущей точки
        }

        yield return new WaitForSeconds(3f); // Ждем 15 секунд

        canShoot = true; // Разрешаем стрельбу снова
    }

    void ShootRocket(Transform firePoint)
    {
        // Создаем экземпляр ракеты на текущей точке стрельбы
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
    }
}
