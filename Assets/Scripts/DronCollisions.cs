using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronCollisions : MonoBehaviour
{
    [SerializeField] GameObject effectHit;
    Rigidbody rb;
    Dron dron;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        dron = GetComponent<Dron>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        Vector3 direction = rb.velocity.normalized;
        GameObject hit = Instantiate(effectHit, gameObject.transform.position, Quaternion.identity);
        Destroy(hit, 1f);
        rb.AddRelativeForce(-direction * 10f, ForceMode.Impulse);
    }

}
