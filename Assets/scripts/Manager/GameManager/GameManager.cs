using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhase { Build, Combat }
    public GamePhase currentPhase = GamePhase.Build;

    [Header("Wasp Settings")]
    public GameObject waspPrefab;   // Drag your Wasp prefab here in Inspector
    public int waspsToSpawn = 3;    // How many to spawn per fight
    public Transform spawnArea;     // Optional: empty object marking spawn zone

    void Update()
    {
        if (currentPhase == GamePhase.Combat)
        {
            Wasp[] wasps = FindObjectsOfType<Wasp>();

            if (wasps.Length == 0)
            {
                SwitchToBuild();
            }
        }
    }

    // Called by the button
    public void StartCombat()
    {
        if (currentPhase == GamePhase.Build)
        {
            currentPhase = GamePhase.Combat;
            NotifyPhaseChange("Combat Phase");

            SpawnWasps();
        }
    }

    private void SwitchToBuild()
    {
        if (currentPhase == GamePhase.Combat)
        {
            currentPhase = GamePhase.Build;
            NotifyPhaseChange("Build Phase");
        }
    }

    private void SpawnWasps()
    {
        for (int i = 0; i < waspsToSpawn; i++)
        {
            Vector3 spawnPos;

            if (spawnArea != null)
            {
                // Random point around the spawn area
                spawnPos = spawnArea.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
            }
            else
            {
                // Default: just somewhere random near the center
                spawnPos = new Vector3(Random.Range(-4f, 4f), Random.Range(-3f, 3f), 0);
            }

            Instantiate(waspPrefab, spawnPos, Quaternion.identity);
        }
    }

    private void NotifyPhaseChange(string phaseName)
    {
        Debug.Log($"Switched to: {phaseName}");
    }
}
