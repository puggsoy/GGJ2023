using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 zerg;
    [SerializeField] float speed = 0.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        zerg = Vector3.forward * (speed * Time.deltaTime);
        rb.MovePosition(transform.position -= zerg);
    }
}
