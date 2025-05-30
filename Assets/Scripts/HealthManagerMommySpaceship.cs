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
            // Если здоровье равно 0, отображаем спрайт смерти (0 HP)
            healthBarImage.sprite = healthBarSprites[0];
        }
        else
        {
            // Иначе вычисляем индекс спрайта на основе текущего здоровья
            int spriteIndex = Mathf.Clamp((mommy.currentHealth - 1) / 20 + 1, 1, healthBarSprites.Length - 1);
            healthBarImage.sprite = healthBarSprites[spriteIndex];
        }
    }
   
}

