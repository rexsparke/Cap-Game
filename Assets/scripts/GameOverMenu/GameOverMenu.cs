using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Reloads the PlayGround scene to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Quits the application (works in builds)
    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();

        // For testing in Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
