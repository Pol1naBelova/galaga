using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooting_For_Rocketeer : MonoBehaviour
{
    public GameObject rocketPrefab; // ������ ������
    public Transform[] firePoints; // ������ �����, ������ ����� �������� ������
    public Transform target;
    private bool canShoot = true; // ����, ������������, ����� �� ��������

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

        yield return new WaitForSeconds(15f); // ���� 15 ������

        canShoot = true; // ��������� �������� �����
    }

    void ShootRocket(Transform firePoint)
    {
        // ������� ��������� ������ �� ������� ����� ��������
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
    }
}
