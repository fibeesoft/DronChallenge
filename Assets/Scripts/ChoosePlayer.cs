using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{
    [SerializeField] Button btnPlayerChooser;
    [SerializeField] Text txtDronName;
    [SerializeField] Slider sliderSpeed, sliderFlexibility, sliderHp, sliderSize, sliderBattery, sliderBoost;

    int playerNumber = 0;
    int levelNumber = 0;

    void Start()
    {
        DisplayPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePlayer()
    {
        if(playerNumber < GameManager.instance.dronePlayerArray.Length - 1)
        {
            playerNumber++;

        }
        else
        {
            playerNumber = 0;
        }
        GameSettings.DroneChoosen = playerNumber;
        DisplayPlayerStats();
    }

    public void DisplayPlayerStats()
    {

        sliderSpeed.maxValue = DronPlayer.speedMax;
        sliderSpeed.value = GameManager.instance.dronePlayerArray[playerNumber].speed;

        sliderFlexibility.maxValue = DronPlayer.flexibilityMax;
        sliderFlexibility.value = GameManager.instance.dronePlayerArray[playerNumber].flexibility;

        sliderHp.maxValue = DronPlayer.hpMax;
        sliderHp.value = GameManager.instance.dronePlayerArray[playerNumber].hp;

        sliderSize.maxValue = DronPlayer.sizeMax;
        sliderSize.value = GameManager.instance.dronePlayerArray[playerNumber].size;

        sliderBattery.maxValue = DronPlayer.batteryMax;
        sliderBattery.value = GameManager.instance.dronePlayerArray[playerNumber].battery;

        sliderBoost.maxValue = DronPlayer.boostMax;
        sliderBoost.value = GameManager.instance.dronePlayerArray[playerNumber].boost;

        txtDronName.text = GameManager.instance.dronePlayerArray[playerNumber].droneName;

    }


    public void ChooseLevel()
    {
        if(levelNumber < GameSettings.LevelsQuantity - 1)
        {
            levelNumber++;
        }
        else
        {
            levelNumber = 0;
        }
        GameSettings.LevelChoosen = levelNumber;
    }
}
