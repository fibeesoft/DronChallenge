using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Kamera : MonoBehaviour
{
    [SerializeField] GameObject dron;
    Vector3 pozycjaDrona;
    Vector3 pozycjaKamery;
     void LateUpdate()
    {
        pozycjaDrona = dron.transform.position;
        pozycjaKamery = new Vector3(dron.transform.position.x, dron.transform.position.y, dron.transform.position.z - 5f);
        transform.position = pozycjaKamery;
    }
}

