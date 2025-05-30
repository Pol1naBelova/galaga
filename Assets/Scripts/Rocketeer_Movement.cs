using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketeer_Movement : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame

    [SerializeField] float verticalSpeed = 3.0f;
    [SerializeField] public float stopYPosition = 0.0f;
    private Transform Player; // Трансформ игрока, за которым следует враг

    private bool reachedPosition = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        // Вертикальное движение к заданной точке
        if (!reachedPosition)
        {
            float step = verticalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, stopYPosition, transform.position.z), step);

            // Проверка достижения позиции
            if (Mathf.Abs(transform.position.y - stopYPosition) < 0.01f)
            {
                reachedPosition = true;
            }
        }
        else // Поворот к игроку
        {
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f; // Поворот на 90 градусов для корректной ориентации
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}