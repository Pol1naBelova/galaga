using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_for_Strelok : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка, откуда будут вылетать пули
    public float fireRate = 1f; // Частота стрельбы (выстрелов в секунду)
    public int bulletsPerQueue = 3; // Количество выстрелов в очереди
    public float queueCooldown = 4f; // Время отката между очередями
    [SerializeField] private float bulletSpeed = 10f; // Скорость пули

    private bool canShoot = true; // Флаг, показывающий, можно ли стрелять
    private int bulletsLeft; // Счетчик оставшихся пуль в текущей очереди

    private void Start()
    {
        bulletsLeft = bulletsPerQueue;
    }

    private void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootQueue());
        }
    }

    IEnumerator ShootQueue()
    {
        canShoot = false; // Запрещаем стрельбу

        for (int i = 0; i < bulletsPerQueue; i++)
        {
            Shoot(); // Стреляем
            bulletsLeft--;

            yield return new WaitForSeconds(1f / fireRate); // Ждем до следующего выстрела
        }

        yield return new WaitForSeconds(queueCooldown); // Ждем время отката
        bulletsLeft = bulletsPerQueue; // Восстанавливаем количество пуль в очереди
        canShoot = true; // Разрешаем стрельбу снова
    }

    void Shoot()
    {
        // Создаем экземпляр пули на точке стрельбы
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Задаем скорость пули вниз по оси Y
        rb.velocity = -firePoint.up * bulletSpeed;
    }


}
