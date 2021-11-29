using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI fuelMeter;
    public TextMeshProUGUI enemiesKilledText;
    
    public GameObject paused;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject quitButton;

    public bool isGamePaused = false;

    public int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Bing");
            isGamePaused = false;
            HidePauseUI();
        }
        else
        {
            if (!isGamePaused && Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("Bada");
                isGamePaused = true;
                DisplayPauseUI();
            }
        } 
    }

    void DisplayPauseUI()
    {
        Time.timeScale = 0;
        paused.SetActive(true);
        //restartButton.SetActive(true);
        //resumeButton.SetActive(true);
        //quitButton.SetActive(true);
    }

    void HidePauseUI()
    {
        Time.timeScale = 1;
        paused.SetActive(false);
        //restartButton.SetActive(false);
        //resumeButton.SetActive(false);
        //quitButton.SetActive(false);
    }

    public void ResumeButton()
    {
        HidePauseUI();
        Debug.Log("Resume");
    }

    public void RestartButton()
    {
        Debug.Log("Restart");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
    }

}
