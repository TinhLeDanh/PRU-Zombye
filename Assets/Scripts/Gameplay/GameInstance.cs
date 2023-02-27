using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance instance;

    [Header("Data")]
    public GameplayRule rule;

    [Header("Components")]
    public BasePlayerCharacterEntity player;
    public CameraController cameraController;
    public MapGenerator MapGenerator;

    protected Vector3 spawnPosition;

    private float timeSpawnCounter;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        Initialization();
        //SpawnPlayer();
    }

    protected void Initialization()
    {
        timeSpawnCounter = 0;
    }

    private void Update()
    {
        SpawnEnemy();
    }

    protected void SpawnPlayer()
    {
        spawnPosition = new Vector3(MapGenerator.MapHeight / 2 + 0.5f, MapGenerator.MapWidth / 2 + 0.5f);
        //spawnPosition = new Vector3(0, 0);
        Instantiate(player.gameObject, spawnPosition, Quaternion.identity);
        cameraController.OnSpawnPlayer(player);
    }

    protected void SpawnEnemy()
    {
        if (timeSpawnCounter > 0)
        {
            timeSpawnCounter -= Time.deltaTime;
        }
        else
        {
            Vector2 spawnPos = Random.insideUnitCircle * player.enemySpawnRadius;
            int randIndex = Random.Range(0, rule.Monsters.Count - 1);
            Instantiate(rule.Monsters[randIndex], spawnPos, Quaternion.identity);
            timeSpawnCounter = rule.TimeSpawnEnemy;
        }
    }
}
