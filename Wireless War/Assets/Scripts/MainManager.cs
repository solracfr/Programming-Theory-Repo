using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Camera mainCamera;
    public Tile tilePrefab;
    public List<Tile> spawnedTiles = new List<Tile>();
    public int tilesToPrespawn = 15;
    public int warmupTiles = 3; // tiles without obstacles to get the player acquianted
    public int score;
    public int movingSpeed;
    public bool gameOver = false;
    public bool gameStarted = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PrespawnTiles();

    }

    void PrespawnTiles()
    {
        Vector3 spawnPos = Vector3.zero;
        Vector3 spawnOffset = new Vector3(0, 0, tilePrefab.prefabLength); // get the length of the prefab as an offset
        int warmupTilesTemp = warmupTiles;

        for (int i = 0; i < tilesToPrespawn; i++)
        {
            Tile tile = Instantiate(tilePrefab, spawnPos, Quaternion.identity, this.transform) as Tile;
            spawnPos += spawnOffset;

            if (warmupTilesTemp > 0)
            {
                tile.DeactivateAllObstacles();
                Debug.Log("obstacles deactivated");
                warmupTilesTemp--;
            }
            else
            {
                tile.ActivateRandomObstacle();
                Debug.Log("random obstacle activated");
            }

            spawnedTiles.Add(tile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // for some reason, moving the lead tile moves them all if referenced from the List
        transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * (movingSpeed + (score/500)), Space.World);
        score += (int)(Time.deltaTime * movingSpeed);
    }
}
