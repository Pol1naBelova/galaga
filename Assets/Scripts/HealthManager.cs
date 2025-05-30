using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image healthBarImage;
    public Sprite[] healthBarSprites;
    public PlayerHealth player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        healthBarImage.sprite = healthBarSprites[player.currentHealth];
    }
}
