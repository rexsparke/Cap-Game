using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScreen : MonoBehaviour
{
    public GlobalManager globalManager;

    GameObject pauseGroupObjects;

    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(globalManager.isPaused == true)
            {

            }
            pauseGroupObjects.transform.localPosition = new Vector3(pauseGroupObjects.transform.localPosition.x + 2000, pauseGroupObjects.transform.localPosition.y, 0f);
        }
    }
    public void resumeButton_OnClick()
    {

    }
}
