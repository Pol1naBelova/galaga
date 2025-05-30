using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Здесь мы создаем переменные, которые можно настроить в Unity
    public float moveSpeed = 5f; // Скорость, с которой корабль будет двигаться вперед или назад
    public float rotationSpeed = 100f; // Скорость, с которой корабль будет поворачиваться влево и вправо

    // Метод Update() вызывается каждый кадр (как если бы мы постоянно обновляли действия корабля)
    void Update()
    {
        // Проверка нажатия клавиши W - движемся вперед
        if (Input.GetKey(KeyCode.W)) // Если игрок нажал W
        {
            // transform.Translate перемещает объект вперед
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // Проверка нажатия клавиши S - движемся назад
        if (Input.GetKey(KeyCode.S)) // Если игрок нажал S
        {
            // -Vector3.forward перемещает объект назад
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // Проверка нажатия клавиши A - вращаемся влево
        if (Input.GetKey(KeyCode.A)) // Если игрок нажал A
        {
            // transform.Rotate вращает объект по вертикальной оси влево
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Проверка нажатия клавиши D - вращаемся вправо
        if (Input.GetKey(KeyCode.D)) // Если игрок нажал D
        {
            // transform.Rotate вращает объект по вертикальной оси вправо
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
