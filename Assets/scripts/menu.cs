using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    //public GameObject settingsCanvas;
    //public GameObject canvas;

    void Start()
    {
        //canvas.SetActive(true);
        //GameManager.inScreen = true;
        //GameManager.isPaused = true;
    }
    void Update()
    {
        //canvas.SetActive(false);
    }
    public void StartButton_OnClick()
    {
        //CloseMenuScreen();
        SceneManager.LoadScene("MainScene");
    }
    public void ExitButton_OnClick()
    {
        Application.Quit(); // This will exit the game when the "Exit" button is pressed
    }
    public void SettingsButton_OnClick()
    {
        CloseMenuScreen();
        //settingsCanvas.SetActive(true);
    }
    public void CloseSettingButtom_OnClick()
    {
        //settingsCanvas.SetActive(false);
        //canvas.SetActive(true);
    }
    private void CloseMenuScreen()
    {
        //canvas.SetActive(false);
        //GameManager.inScreen = false;
        //GameManager.isPaused = false;
    }
}
