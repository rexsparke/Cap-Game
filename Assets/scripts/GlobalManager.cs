using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public bool canPlace;
    public bool isPaused;
    public int waveNumber;
    public bool buildPase;
    public bool attackPase;
    public int hiveHealth;
    public int maxHiveHealth;
    public bool isDead;


    void Awake()
    {
        canPlace = false;
        buildPase = true;
        attackPase = false;
        waveNumber = 0;
        isPaused = false;
        maxHiveHealth = 100;
        hiveHealth = maxHiveHealth;
        isDead = false;
    }
}
