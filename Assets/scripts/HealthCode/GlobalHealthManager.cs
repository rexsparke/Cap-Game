using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // <-- needed for scene switching

public class GlobalHealthManager : MonoBehaviour
{
    public Slider globalHealthBar;
    private int totalHoneycombs;
    private int remainingHoneycombs;

    private void Start()
    {
        // Count honeycombs currently in the scene
        totalHoneycombs = GameObject.FindGameObjectsWithTag("HoneyComb").Length;
        remainingHoneycombs = totalHoneycombs;

        // Set up the health bar
        if (globalHealthBar != null)
        {
            globalHealthBar.maxValue = totalHoneycombs;
            globalHealthBar.value = totalHoneycombs;
        }
    }

    public void OnHoneycombDestroyed()
    {
        remainingHoneycombs--;

        if (globalHealthBar != null)
            globalHealthBar.value = remainingHoneycombs;

        Debug.Log("Honeycomb destroyed! Remaining: " + remainingHoneycombs);

        if (remainingHoneycombs <= 0)
        {
            Debug.Log("All honeycombs destroyed — GAME OVER");
            SceneManager.LoadScene("GameOverScene"); // <-- make sure names match!
        }
    }
}
