using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Dron target;
    Vector3 targetPos;
    Vector3 offset;
    void Start()
    {
        target = GameObject.FindObjectOfType<Dron>();
        offset = new Vector3(0f, 0.4f, -0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = target.transform.position;
        transform.localRotation = target.transform.localRotation;
    }

    private void FixedUpdate()
    {
        transform.position = targetPos + offset;
        print(targetPos);
    }
}
