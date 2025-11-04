using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public bool canPlace;
    public bool isPaused;

    void Start()
    {
        canPlace = false;
    }
}
