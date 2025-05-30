using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_for_Strelok : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform firePoint; // �����, ������ ����� �������� ����
    public float fireRate = 1f; // ������� �������� (��������� � �������)
    public int bulletsPerQueue = 3; // ���������� ��������� � �������
    public float queueCooldown = 4f; // ����� ������ ����� ���������
    [SerializeField] private float bulletSpeed = 10f; // �������� ����

    private bool canShoot = true; // ����, ������������, ����� �� ��������
    private int bulletsLeft; // ������� ���������� ���� � ������� �������

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
        canShoot = false; // ��������� ��������

        for (int i = 0; i < bulletsPerQueue; i++)
        {
            Shoot(); // ��������
            bulletsLeft--;

            yield return new WaitForSeconds(1f / fireRate); // ���� �� ���������� ��������
        }

        yield return new WaitForSeconds(queueCooldown); // ���� ����� ������
        bulletsLeft = bulletsPerQueue; // ��������������� ���������� ���� � �������
        canShoot = true; // ��������� �������� �����
    }

    void Shoot()
    {
        // ������� ��������� ���� �� ����� ��������
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // ������ �������� ���� ���� �� ��� Y
        rb.velocity = -firePoint.up * bulletSpeed;
    }


}
