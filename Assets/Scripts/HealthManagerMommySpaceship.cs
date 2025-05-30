using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerMommySpaceship : MonoBehaviour
{
    public Image healthBarImage;
    public Sprite[] healthBarSprites;
    public MommySpaceship mommy;

    private void Start()
    {
        mommy = GameObject.Find("MommySpaceship").GetComponent<MommySpaceship>();
    }
    // Update is called once per frame
    void Update()
    {
        if (mommy.currentHealth == 0)
        {
            // ���� �������� ����� 0, ���������� ������ ������ (0 HP)
            healthBarImage.sprite = healthBarSprites[0];
        }
        else
        {
            // ����� ��������� ������ ������� �� ������ �������� ��������
            int spriteIndex = Mathf.Clamp((mommy.currentHealth - 1) / 20 + 1, 1, healthBarSprites.Length - 1);
            healthBarImage.sprite = healthBarSprites[spriteIndex];
        }
    }
   
}

