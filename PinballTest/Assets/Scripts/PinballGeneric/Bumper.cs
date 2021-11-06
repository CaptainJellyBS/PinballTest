using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumperForce;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = (transform.position - collision.transform.position).normalized;
        rb.AddForce(direction * bumperForce, ForceMode.Impulse);
    }
}
