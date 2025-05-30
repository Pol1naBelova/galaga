using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����� �� ������ ��������� ��� �������, ����� ���������, ��� ��� ������, ������� ������ �������� ����
        if (other.gameObject.tag == "Player") 
            // �����������, ��� ������, ��������� ����, ����� ��� "DamageSource"
        {
            Invoke("Explode", 0.2f); // ������� ���� �����, ���������� ����� ����� ��������
        }
        if (other.gameObject.tag == "PlayerBullet")
        {
            Invoke("Explode", 0.2f);
        }
    }
    // ��������� ���������� �������� �����
    public GameObject explosionPrefab; // ������ ������� ������
    private void Update()
    {
        // �������� ���������� �� ��� Y
        if (transform.position.y <= -7.6f)
        {
            Explode();
        }
    }
    

    // ����� ��� ��������� ����� �����
   
    // ����� ��� ������
    private void Explode()
    {
        // ������� ������ ������ �� ����� �����
        GameObject exp = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exp, 0.2f);
        // ���������� ������ �����
        Destroy(gameObject);
    }

}
