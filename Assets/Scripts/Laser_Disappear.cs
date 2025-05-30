using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Disappear : MonoBehaviour
{
    public float timeOfLife = 0.83f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeOfLife -= Time.deltaTime;
        if (timeOfLife <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
