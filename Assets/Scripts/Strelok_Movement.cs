using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelok_Movement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    [SerializeField] public float verticalSpeed = 3.0f;
    [SerializeField] public float horizontalSpeed = 5.0f;
    [SerializeField] public float stopYPosition = 0.0f;
    private bool reachedPosition = false;

    private float changeTime = 2.0f;
    private float timer = 0.0f;
    private int direction = 1;
    public Animator anim;
    void Update()
    {
        // ¬ертикальное движение к заданной точке
        if (!reachedPosition)
        {
            float step = verticalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, stopYPosition, transform.position.z), step);

            if (Mathf.Abs(transform.position.y - stopYPosition) < 0.01f)
            {
                reachedPosition = true;
            }
        }
        else // –андомное горизонтальное движение
        {
            timer += Time.deltaTime;

            if (timer > changeTime)
            {
                direction *= -1; // »зменить направление на противоположное
                timer = 0.0f;
                changeTime = Random.Range(1.0f, 5.0f); // —лучайное врем€ до следующего изменени€ направлени€
            }

            transform.Translate(Vector3.right * direction * horizontalSpeed * Time.deltaTime);
        }
        

    }
}
