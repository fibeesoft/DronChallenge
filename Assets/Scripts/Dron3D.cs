using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron3D : MonoBehaviour
{
    Dron dron;
    GameObject[] propellers;
    void Start()
    {
        dron = GetComponentInParent<Dron>();
        propellers = GameObject.FindGameObjectsWithTag("Propeller");
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(Input.GetAxis("Vertical") * 15f, 0f, Input.GetAxis("Horizontal") * -35f);
        foreach (var prop in propellers)
        {
            if(prop.name.Substring(1) == "cw")
            {
                prop.transform.Rotate(0f, (20f + 5f * dron.DroneActualSpeed), 0f, Space.Self);
            }
            if (prop.name.Substring(1) == "ccw")
            {
                prop.transform.Rotate(0f, (20f + 5f * dron.DroneActualSpeed) * -1, 0f, Space.Self);
            }
        }
    }
}
