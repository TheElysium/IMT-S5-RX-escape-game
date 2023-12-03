using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrabbable : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    private Rigidbody rb;

    private void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        initialRotation = transform.rotation.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    public void Respawn()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = initialPosition;
        transform.eulerAngles = initialRotation;

        rb.useGravity = true;
    }
}
