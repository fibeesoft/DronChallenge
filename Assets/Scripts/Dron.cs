using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dron : MonoBehaviour
{
    float speed, rotateSpeed, upDownSpeed;
    float accelerate, leftRight, upDown;
    float battery, batteryMax, hpMax, hp;
    Slider sliderBattery, sliderHP;
    [SerializeField] GameObject dron3dmodel;
    float clampY = 1f;
    Rigidbody rb;

    void Start() {
        speed = 30;
        rotateSpeed = 100;
        upDownSpeed = 20;
        rb = GetComponent<Rigidbody>();
        sliderBattery = GameObject.FindGameObjectWithTag("SliderBattery").GetComponent<Slider>();
        sliderHP = GameObject.FindGameObjectWithTag("SliderHP").GetComponent<Slider>();
    }

    
    void Update()
    {
        UpdateUIStats();
            DrainBattery();
            accelerate = Input.GetAxisRaw("Vertical");
            leftRight = Input.GetAxisRaw("Horizontal");
            if(Input.GetKey(KeyCode.K)){
                upDown = 1;
            }else if(Input.GetKey(KeyCode.M)){
                upDown = -1;
            }else{
                upDown = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
            transform.Rotate(0f, leftRight * Time.deltaTime * rotateSpeed, 0f, Space.Self);
       

    }

    void Shoot()
    {
        print("shoot");
    }
    private void FixedUpdate()
    {
        /*
        if (true)
        {
            Vector3 pos = rb.position;
            pos.y = Mathf.Clamp(pos.y, 0f, clampY);
            rb.position = pos;
        }
        */

        rb.AddRelativeForce(new Vector3(0f, upDown * upDownSpeed, accelerate * speed));
        
    }


    void DrainBattery()
    {
        if(battery > 0)
        {
           battery -= 0.05f * Time.deltaTime;
        }
        else
        {
            //print("battery empty");
        }
    }

    void UpdateUIStats()
    {
        sliderBattery.value = battery;
        sliderHP.value = hp;
    }


    public void RestoreBattery()
    {
        battery += batteryMax * 0.2f;
        if(battery > batteryMax)
        {
            battery = batteryMax;
        }
    }
}


