using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public int currentWave = 1;

    private GameplayRule gameplayRule;

    private void Awake()
    {
        instance = this;
        gameplayRule = GameInstance.instance.rule;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        SpawnEnemy();
    }

    public void OnLevelUp()
    {
        currentWave++;
    }

    public void SpawnEnemy()
    {
        foreach (MonsterWave monsterWave in gameplayRule.monsterWave)
        {

        }
    }


}
