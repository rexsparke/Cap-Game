using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexInShop : MonoBehaviour
{
    public GameObject hexOutline;
    bool selected = false;

    private void OnMouseDown()
    {
        bool selected = true;
        Instantiate(hexOutline, transform.position, Quaternion.identity);
    }
}
