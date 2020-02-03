using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronCollisions : MonoBehaviour
{
    [SerializeField] GameObject effectHit;
    LevelManager levelManager;
    Rigidbody rb;
    Dron dron;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelManager = FindObjectOfType<LevelManager>();
        dron = GetComponent<Dron>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        dron.GetDamage(1);
        Vector3 direction = rb.velocity.normalized;
        GameObject hit = Instantiate(effectHit, gameObject.transform.position, Quaternion.identity);
        Destroy(hit, 1f);
        rb.AddRelativeForce(-direction * 10f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Finish"))
        {
            Destroy(other.gameObject, 0f);
            levelManager.FinishLevel();
            
        }

        if (other.transform.CompareTag("Battery"))
        {
            dron.RestoreBattery();
            Destroy(other.gameObject);
        }
    }


}
