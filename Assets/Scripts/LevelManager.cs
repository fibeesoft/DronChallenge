using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    GameObject colliders;
    [SerializeField] GameObject dronPrefab;
    [SerializeField] Text txtCounter, txtCountDown, txtFinishTime;
    Dron dron;

    float counter = 0f;
    bool hasGameStarted = false;
    float countDownValue = 3;
    bool isCountingDownActive = true;
    void Start()
    {
        txtFinishTime.enabled = false;
        GameObject g = Instantiate(dronPrefab, Vector3.zero, Quaternion.identity);
        dron = FindObjectOfType<Dron>();
        //dron.HasGameStarted = true; // To be deleted to keep counting down
        colliders = GameObject.FindGameObjectWithTag("ColContainer");
        colliders.SetActive(GameSettings.IsColliderOn);
    }

    void Update()
    {
        CountDown();
        if (hasGameStarted)
        {
            counter += Time.deltaTime;
            if(txtCounter != null)
            {
                txtCounter.text = counter.ToString("0.00");
            }
        }
    }

    void CountDown()
    {
        if (isCountingDownActive)
        {
            if(countDownValue > 0)
            {
                countDownValue -= Time.deltaTime;
                txtCountDown.text = countDownValue.ToString("0");
            }
            else
            {
                hasGameStarted = true;
                dron.HasGameStarted = true;
                txtCountDown.enabled = false;
                isCountingDownActive = false;
            
            }
        }
    }

    public void FinishLevel()
    {
        GameSettings.LastTime = counter;
        if(counter < GameSettings.LowestTime || GameSettings.LowestTime == 0)
        {
            GameSettings.LowestTime = counter;
        }

        dron.HasGameStarted = false;
        hasGameStarted = false;
        txtFinishTime.enabled = true;
        txtFinishTime.text = "Your score: " + counter;

        StartCoroutine(ShowFinishMessage());

    }

    IEnumerator ShowFinishMessage()
    {
        yield return new WaitForSeconds(2f);
        GameManager.instance.LoadMenu();
    }
}
