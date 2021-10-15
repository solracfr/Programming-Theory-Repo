using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Camera mainCamera;
    public Player player;
    public Tile tilePrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI timerText;
    public List<Tile> spawnedTiles = new List<Tile>();
    public int tilesToPrespawn = 15;
    public int warmupTiles = 3; // tiles without obstacles to get the player acquianted
    public float score;
    public float timeLeft;
    public int movingSpeed = 5;
    public int MovingSpeed
    {
        get {return movingSpeed;}

        set
        {
            if (value < 0) 
                Debug.LogError("Can't set to a negative number!");
            else 
                Debug.Log($"Multiplied track speed by {value}");
                movingSpeed = value;
        }
    }
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
        // abstraction
        PrespawnTiles();
        //Debug.Log(player.HP);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            gameStarted = true;
        }

        if (gameStarted)
        {
            // for some reason, moving the lead tile moves them all if referenced from the List
            transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * (movingSpeed + (score / 500)), Space.World);
            score += Time.deltaTime * movingSpeed;
            timeLeft -= Time.deltaTime;
            UpdateUI();
        }

        RegenerateTiles();

    }

    void RegenerateTiles()
    {
        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].transform.position).z < -spawnedTiles[0].prefabLength / 2)
        {
            Tile tileTemp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTemp.transform.position = spawnedTiles[spawnedTiles.Count - 1].transform.position + new Vector3(0, 0, tileTemp.prefabLength);
            tileTemp.ActivateRandomObstacle();
            spawnedTiles.Add(tileTemp);
        }
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

    void UpdateUI()
    {
        scoreText.text = $"Score: {(int)score}";
        lifeText.text = $"Life: {player.HP}";
        timerText.text = $"Time Left: {(int)timeLeft}";
    }
}
