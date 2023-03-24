using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float showTxtTime;

    public int currentWave = 0;
    public int currentEnemyInWave = 0;

    private GameplayRule gameplayRule;

    private void Awake()
    {
        instance = this;
        gameplayRule = GameInstance.instance.rule;
    }

    private void Start()
    {
    }

    public void OnNextWave()
    {
        if (GameInstance.instance.state == GameInstance.GameState.LoadMap)
        {
            return;
        }

        currentWave++;
        UIManager.instance.gameTitleTxt.text = "Wave " + currentWave.ToString();
        SpawnEnemy();
        StartCoroutine(ShowCO());
    }

    IEnumerator ShowCO()
    {
        UIManager.instance.gameTitleTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(showTxtTime);
        UIManager.instance.gameTitleTxt.gameObject.SetActive(false);
    }

    public void OnKilledEnemy()
    {
        currentEnemyInWave--;
        if (currentEnemyInWave <= 0)
        {
            OnNextWave();
        }
    }

    public void SpawnEnemy()
    {
        if (GameInstance.instance.state != GameInstance.GameState.StartGame)
        {
            return;
        }

        foreach (MonsterWave monsterWave in gameplayRule.monsterWave)
        {
            if (currentWave % monsterWave.spawnRange == 0)
            {
                Spawn(monsterWave.monster, monsterWave.unitPerWave + (currentWave - 1) / monsterWave.spawnRange);
                currentEnemyInWave = monsterWave.unitPerWave * currentWave;
            }
        }
    }

    protected void Spawn(BaseGameEntity entity, int amount)
    {
        if (GameInstance.instance.state != GameInstance.GameState.StartGame)
        {
            return;
        }

        Debug.Log(amount);
        int amountCounter = amount;
        while (amountCounter > 0)
        {
            BasePlayerCharacterEntity player = GameInstance.instance.player;
            int rand = Random.Range(0, GameInstance.instance.MapGenerator.floorPosition.Count);
            Vector2 spawnPos = GameInstance.instance.MapGenerator.floorPosition[rand];
            int randIndex = Random.Range(0, gameplayRule.monsterWave.Count - 1);
            BaseGameEntity newEntity = Instantiate(entity, spawnPos, Quaternion.identity);
            StartCoroutine(spawnTimeCO(gameplayRule.TimeSpawnEnemy));
            amountCounter--;
        }
    }

    IEnumerator spawnTimeCO(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
