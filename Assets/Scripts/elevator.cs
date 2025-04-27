using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Rigidbody rb;
    public Transform targetPosition; // posición final arriba
    public float speed = 2f;

    private bool activated = false;
    private bool reachedTarget = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (activated && !reachedTarget)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);

            if (Vector3.Distance(rb.position, targetPosition.position) < 0.01f)
            {
                reachedTarget = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activated = true;
        }
    }
}

