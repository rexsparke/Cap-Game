using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public bool canPlace;
    public bool isPaused;
    public int waveNumber;


    void Start()
    {
        canPlace = false;
    }
}
