using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhase { Build, Combat }
    public GamePhase currentPhase = GamePhase.Build;

    [Header("Wasp Settings")]
    public GameObject waspPrefab;   // Drag your Wasp prefab here in Inspector
    public int waspsToSpawn = 3;    // How many to spawn per fight
    public Transform spawnArea;     // Optional: empty object marking spawn zone
    PlacementManager placeManger;

    GameObject randomTile;
    public GameObject[] spawnHexes;
    public GameObject shopBack;
    GlobalManager globalManager;
    GameObject[] shopTiles = new GameObject[3];


    void Start()
    {
        globalManager = GetComponent<GlobalManager>();
    }

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
    public void StartCombat_OnClick()
    {
        if (currentPhase == GamePhase.Build)
        {
            randomTile = GameObject.FindGameObjectWithTag("BoardHex");  //Checking player actually places starting tile
            if(randomTile != null)
            {
                Debug.Log("About to Start Attack phase");
                startAttackPhase(shopTiles);

                NotifyPhaseChange("Combat Phase");
                //spawnHexes = GameObject.FindGameObjectsWithTag("BoardHex");
                //foreach (GameObject hex in spawnHexes)
                //{
                //    hex.SendMessage("Spawn");
                //}
                SpawnWasps();
                currentPhase = GamePhase.Combat;
            }
            else
            {
                Debug.Log("Player did not place a starting tile");
            }
            
        }
    }

    private void SwitchToBuild()
    {
        if (currentPhase == GamePhase.Combat)
        {
            currentPhase = GamePhase.Build;
            NotifyPhaseChange("Build Phase");
            ReappearShop(shopTiles);

            //EndBuildPase(); //For Reappearing shop menu
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
    public void EndBuildPase()
    {
        GameObject[] shopTiles = new GameObject[3];
        shopTiles = GameObject.FindGameObjectsWithTag("ShopHex");

        if (currentPhase == GamePhase.Combat)
        {
            shopBack.transform.localPosition = new Vector3(shopBack.transform.localPosition.x - 400, shopBack.transform.localPosition.y, 0);
            foreach (GameObject shopTile in shopTiles)
            {
                shopTile.transform.localPosition = new Vector3(shopTile.transform.localPosition.x - 5, shopTile.transform.localPosition.y, 0);
            }
            Debug.Log("ShopTiles were moved");
        }
        else if (currentPhase == GamePhase.Build)
        {
            shopBack.transform.localPosition = new Vector3(shopBack.transform.localPosition.x + 400, shopBack.transform.localPosition.y, 0);
            foreach (GameObject shopTile in shopTiles)
            {
                shopTile.transform.position = new Vector3(shopTile.transform.position.x + 5, shopTile.transform.position.y, 0);
            }
        }
    }
    public void ReappearShop(GameObject[] shoptiles)
    {
        Debug.Log("Am in reappearShop funtion");
        shoptiles = GameObject.FindGameObjectsWithTag("ShopHex");
        shopBack.transform.localPosition = new Vector3(shopBack.transform.localPosition.x - 400, shopBack.transform.localPosition.y, 0);
        foreach (GameObject shopTile in shoptiles)
        {
            shopTile.transform.localPosition = new Vector3(shopTile.transform.localPosition.x - 5, shopTile.transform.localPosition.y, 0);
        }
        Debug.Log("ShopTiles were moved");
    }
    public void DiappearShop(GameObject[] shoptiles)
    {
        shoptiles = GameObject.FindGameObjectsWithTag("ShopHex");
        shopBack.transform.localPosition = new Vector3(shopBack.transform.localPosition.x + 400, shopBack.transform.localPosition.y, 0);
        foreach (GameObject shopTile in shoptiles)
        {
            shopTile.transform.position = new Vector3(shopTile.transform.position.x + 5, shopTile.transform.position.y, 0);
        }
        
    }
    public void startAttackPhase(GameObject[] shoptiles)
    {
        Debug.Log("Starting attack phase");
        globalManager.buildPase = false;
        globalManager.attackPase = true;
        Debug.Log("Attack Pase is: " +  globalManager.attackPase);
        DiappearShop(shopTiles);
        EndBuildPase();
    }
}
