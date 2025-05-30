using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_attack_boss : MonoBehaviour
{
    public GameObject rocketPrefab; // ������ ������
    public Transform[] firePoints; // ������ �����, ������ ����� �������� ������
    public Transform target;
    private bool canShoot = true; // ����, ������������, ����� �� ��������
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
        canShoot = false; // ��������� ��������

        foreach (Transform firePoint in firePoints)
        {
            ShootRocket(firePoint); // �������� ������� �� ������� �����
        }

        yield return new WaitForSeconds(3f); // ���� 15 ������

        canShoot = true; // ��������� �������� �����
    }

    void ShootRocket(Transform firePoint)
    {
        // ������� ��������� ������ �� ������� ����� ��������
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
    }
}
