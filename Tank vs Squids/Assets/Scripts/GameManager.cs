using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI fuelMeter;
    public TextMeshProUGUI enemiesKilledText;
    public TextMeshProUGUI paused;

    public bool isGamePaused = false;

    public int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isGamePaused)
            {
                isGamePaused = false;
                DisplayPauseUI();
            }
        }

    }

    void DisplayPauseUI()
    {
        paused.gameObject.SetActive(true);
        GameObject.Find("Resume Button").SetActive(true);
        Debug.Log("Test");
        Debug.Log(GameObject.Find("Resume Button").GetType());
    }
}
