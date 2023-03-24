using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public enum GameState
    {
        LoadMap,
        StartGame,
        GameOver
    }

    public static GameInstance instance;

    [Header("Data")]
    public GameplayRule rule;

    [Header("Components")]
    public BasePlayerCharacterEntity player;
    public CameraController cameraController;
    public MapGenerator MapGenerator;
    public WaveManager waveManager;

    [Header("Gameplay")]
    public GameState state;
    public float loadMapCameraSize;
    public float gameCameraSize;
    public float exp;
    public float playerLevel;
    public List<MonsterCharacterEntity> monsters;

    protected Vector3 spawnPosition;

    private Camera cam;

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
        cam = Camera.main;
        cam.orthographicSize = loadMapCameraSize;
        cameraController.OnSpawnPlayer(player);
        state = GameState.LoadMap;
    }

    private void Update()
    {

    }

    public void MapLoaded()
    {
        cam.orthographicSize = gameCameraSize;
        UIManager.instance.MapLoaded();
        StartGame();
    }

    public void StartGame()
    {
        state = GameState.StartGame;
        waveManager.OnNextWave();
    }

    public void GameOver()
    {
        state = GameState.GameOver;
        UIManager.instance.GameOver();
    }

    protected void SpawnPlayer()
    {
        spawnPosition = new Vector3(MapGenerator.MapHeight / 2 + 0.5f, MapGenerator.MapWidth / 2 + 0.5f);
        //spawnPosition = new Vector3(0, 0);
        Instantiate(player.gameObject, spawnPosition, Quaternion.identity);
    }

    
}
