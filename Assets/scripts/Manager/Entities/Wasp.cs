using UnityEngine;

public class Wasp : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);  // clicking kills the wasp
    }
}

