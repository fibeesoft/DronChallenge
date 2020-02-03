using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Toggle toggleColliders;
    [SerializeField] Text txtLowestTime;
    void Start()
    {
        toggleColliders.isOn = GameSettings.IsColliderOn;
        toggleColliders.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggleColliders);
        });
        if(GameSettings.LowestTime == 0)
        {
            txtLowestTime.text = "";
        }
        else
        {
            txtLowestTime.text = "Best Time: " + GameSettings.LowestTime.ToString("00.00");
        }
    }

    void ToggleValueChanged(Toggle change)
    {
        GameSettings.IsColliderOn = change.isOn;
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(GameSettings.LevelChoosen + 1);
    }
}
