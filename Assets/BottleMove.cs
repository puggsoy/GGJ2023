using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMove : MonoBehaviour
{
    public float forceMult = 200;
    private Rigidbody rb;
    private Vector3 zerg;
    private float speed = 0.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = speed * Time.deltaTime;
    }

    private void Update()
    {
        zerg = transform.position -= transform.forward * speed;

        rb.MovePosition(transform.position -= transform.forward * Time.deltaTime);
    }
}
