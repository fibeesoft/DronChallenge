using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dron : MonoBehaviour
{
    string droneName;
    float speed;
    float flexibility;
    int hp,hpMax;
    float size;
    float battery,batteryMax;
    float boost,boostMax;
    Slider sliderBattery, sliderHP, sliderBoost;
    bool isBoostActivated = false;
    [SerializeField] Camera cam;

    [SerializeField] GameObject dron3dmodel;

    float accelerate, leftRight, upDown, upDownSpeed = 1.2f;
    
    float droneBaseSpeed = 4f, droneBonusSpeed = 1, droneActualSpeed;
    float clampY = 1f;
    public bool HasGameStarted { get; set; }
    
    public float DroneActualSpeed { 
        get { return droneActualSpeed; } 
    }

    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
        transform.position = GameSettings.SpawnPosition;
        sliderBattery = GameObject.FindGameObjectWithTag("SliderBattery").GetComponent<Slider>();
        sliderHP = GameObject.FindGameObjectWithTag("SliderHP").GetComponent<Slider>();
        sliderBoost = GameObject.FindGameObjectWithTag("SliderBoost").GetComponent<Slider>();
        InitializeStats();
    }

    
    void Update()
    {
        UpdateUIStats();
        if (HasGameStarted)
        {
            DrainBattery();
            TurnBoostOn();
            accelerate = Input.GetAxisRaw("Vertical");
            leftRight = Input.GetAxisRaw("Horizontal");
            droneActualSpeed = (isBoostActivated ? speed*2 : speed) * accelerate * droneBaseSpeed * droneBonusSpeed;
            if(Input.GetKey(KeyCode.R)){
                upDown = 1;
            }else if(Input.GetKey(KeyCode.F)){
                upDown = -1;
            }else{
                upDown = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isBoostActivated = true;
            }
            transform.Rotate(0f, leftRight * flexibility * 30f * droneBaseSpeed * Time.deltaTime, 0f,Space.Self);
            
        }
        else
        {
            accelerate = 0f;
            leftRight = 0f;
            upDown = 0f;
            droneActualSpeed = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (GameSettings.IsColliderOn)
        {
            Vector3 pos = rb.position;
            pos.y = Mathf.Clamp(pos.y, 0f, clampY);
            rb.position = pos;
        }

        rb.AddRelativeForce(new Vector3(0f, flexibility * upDown * upDownSpeed * 10f, droneActualSpeed * 10f));
        
    }

    public void InitializeStats()
    {
        int droneChoosen = GameSettings.DroneChoosen;
        droneName = GameManager.instance.dronePlayerArray[droneChoosen].droneName;
        speed = GameManager.instance.dronePlayerArray[droneChoosen].speed;
        flexibility = GameManager.instance.dronePlayerArray[droneChoosen].flexibility;
        hpMax = hp = GameManager.instance.dronePlayerArray[droneChoosen].hp;
        size = GameManager.instance.dronePlayerArray[droneChoosen].size;
        batteryMax = battery = GameManager.instance.dronePlayerArray[droneChoosen].battery;
        boostMax = boost = GameManager.instance.dronePlayerArray[droneChoosen].boost;
        dron3dmodel.transform.localScale = new Vector3(size, size, size);
        BoxCollider col = GetComponent<BoxCollider>();
        col.size *= size ;
        float camZpos = cam.transform.position.z;
        float camYpos = cam.transform.position.y;
        //camZpos *= size * size;
        //0.6 = 1 - 0.6 = 0.4 x 0.3 = 0.12
        // 0.8 = 0.2 x 0.3 = 0.06
        cam.transform.localPosition = new Vector3(0f, size * 0.02f + 0.1f*size, camZpos * size );
        sliderBoost.maxValue = boostMax;
        sliderBattery.maxValue = batteryMax;
        sliderHP.maxValue = hpMax;
    }

    public void GetDamage(int damage)
    {
        if(hp > 0)
        {
            hp -= damage;
        }
        else
        {
            print("you died");
            GameManager.instance.LoadMenu();
        }
    }

    void DrainBattery()
    {
        if(battery > 0)
        {
            if (isBoostActivated)
            {
                battery -= 0.08f * Time.deltaTime;
            }
            else
            {
                battery -= 0.05f * Time.deltaTime;
            }
        }
        else
        {
            print("battery empty");
            GameManager.instance.LoadMenu();
        }
    }

    void UpdateUIStats()
    {
        sliderBattery.value = battery;
        sliderHP.value = hp;
        sliderBoost.value = boost;
    }

    void TurnBoostOn()
    {
        if (isBoostActivated)
        {
            if(boost > 0)
            {
                
                boost -= 0.5f * Time.deltaTime;
            }
            else
            {
                isBoostActivated = false;
            }
        }
        else
        {
            if(boost < boostMax)
            {
                boost += 0.2f * boostMax * Time.deltaTime;
            }
        }
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


