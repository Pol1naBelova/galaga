using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class boss_manager : MonoBehaviour
{
    public rocket_attack_boss Rocket_Attack_Boss;
    public bomb_attack_boss Bomb_Attack_Boss;
    
    public float delayTime;
    private float timer;
    private MonoBehaviour currentAttack;
    public static boss_manager Instance { get; private set; }
    private Vector2 targetPosition = new Vector2(-0.22f, 4f);
    public float moveSpeed = 2f;
    private bool reachedTargetPosition = false;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DisableAllAttacks();
    }

    private void Update()
    {
        if (!reachedTargetPosition)
        {
            MoveToStartPosition();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= delayTime && currentAttack == null)
            {
                StartRandomAttack();
                timer = 0f;
            }
        }
    }
    private void MoveToStartPosition()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            reachedTargetPosition = true;
            timer = delayTime;  // Сразу запустим первую атаку
        }
    }

    private void StartRandomAttack()
    {
        int randomizer = Random.Range(1, 3);
        switch (randomizer)
        {
            case 1:
                StartAttack(Rocket_Attack_Boss, Rocket_Attack_Boss.attackDuration);
                break;
            case 2:
                StartAttack(Bomb_Attack_Boss, Bomb_Attack_Boss.attackDuration);
                break;
           
        }
    }

    private void StartAttack(MonoBehaviour attack, float duration)
    {
        currentAttack = attack;
        
        attack.enabled = true;
        Invoke("EndCurrentAttack", duration);
    }

    public void EndCurrentAttack()
    {
    
        currentAttack.enabled = false;
        currentAttack = null;
    }

    private void DisableAllAttacks()
    {
        
            Bomb_Attack_Boss.enabled = false;

        
            Rocket_Attack_Boss.enabled = false;
        
  
    }
}


