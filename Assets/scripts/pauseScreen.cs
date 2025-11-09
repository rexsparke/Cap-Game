using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScreen : MonoBehaviour
{
    public GlobalManager globalManager;

    bool inScreen = false;
    GameObject pauseGroupObjects;

    void Start()
    {
        pauseGroupObjects = this.gameObject;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inScreen)
            {
                OpenPauseScreen();
            }
            //Closes UI screen while in UI screen
            else
            {
                ClosePauseScreen();
            }
        }
    }
    public void OpenPauseScreen()
    {
        globalManager.isPaused = true;
        inScreen = true;
        Time.timeScale = 0f;
        pauseGroupObjects.transform.localPosition = new Vector3(pauseGroupObjects.transform.localPosition.x - 1950, pauseGroupObjects.transform.localPosition.y, 0f);
    }
    public void ClosePauseScreen()
    {
        globalManager.isPaused = false;
        inScreen = false;
        Time.timeScale = 1f;
        pauseGroupObjects.transform.localPosition = new Vector3(pauseGroupObjects.transform.localPosition.x + 1950, pauseGroupObjects.transform.localPosition.y, 0f);

    }
    public void option_OnClick()
    {

    }
    public void returnToMenut_OnClick()
    {
        SceneManager.LoadScene("Menu");
    }
    public void exit_OnClick()
    {
        Application.Quit();
    }
}
