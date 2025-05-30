using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotateSpeed = 150f;
    public float time_of_life = 12f;
    private Rigidbody2D rb;
    private float rocket_y;
    private float player_y;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 direction = (Vector2)target.position - rb.position;
        float rotateAmount = Vector3.Cross(direction, -transform.up).z;
        rb.velocity = -transform.up * speed;
        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rocket_y = transform.position.y;
        player_y = target.transform.position.y;
        if (rocket_y <= (player_y + 5))
        {
            rb.velocity = -transform.up * speed;
            rb.angularVelocity = 0;
        }

        time_of_life -= Time.deltaTime;
        if (time_of_life <= 0)
        {
            Destroy(gameObject);
        }

    }

}
