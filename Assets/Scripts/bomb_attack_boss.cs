using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_attack_boss : MonoBehaviour
{
    public GameObject bombPrefab; // ������ �����
    public Transform[] firePoints; // ������ firepoints
    public float fireInterval = 2.5f; // �������� ��������
    public float bombSpeed = 2.0f;
    private Rigidbody2D rb;
    private float timeSinceLastFire;
    public float attackDuration;

    void Start()
    {
        rb = bombPrefab.GetComponent<Rigidbody2D>();
        timeSinceLastFire = fireInterval; // ������������� ��������� �������� ��� �������
    }

    void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        if (timeSinceLastFire >= fireInterval)
        {
            FireBombs();
            timeSinceLastFire = 0f;
        }
    }

    void FireBombs()
    {
        // �������� �� ���� firepoints � ������� ����� �� ������ �� ���
        foreach (Transform firePoint in firePoints)
        {
            GameObject Bomb = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            rb = Bomb.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -bombSpeed);
        }
    }


}
