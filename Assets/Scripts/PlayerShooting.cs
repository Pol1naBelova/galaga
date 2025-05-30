using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    float bulletSpeed = 20.0f;
    float shootingRate = 0.2f;
    float shootingCooldown;
    public AudioClip shootingSound; // ������ �� ��������� ������
    private AudioSource audioSource;

    private void Start()
    {
        // �������� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();

        // ���������, ��� ��������� ����������
        if (shootingSound == null)
        {
            Debug.LogError("Explosion sound is not assigned!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        shootingCooldown -= Time.deltaTime;

        if (shootingCooldown <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            shootingCooldown = shootingRate;
        }

    }
    public void Ultimate()
    {
        shootingRate = 0.01f;
    }
    public void UltimateOver()
    {
        shootingRate = 0.02f;
    }
    void PlayShootSound()
    {
        if (audioSource != null && shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }
    }

        void Shoot()
    {
        // ������ ����� ������� ������� � �������� ������� � � �������� �����������
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        PlayShootSound();


        // ����������� ������� �������� � �����������, ��������� �� ���������� �������, � �������� ��������� ������
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
