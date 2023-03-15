using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.GameplayRule_FileName, menuName = GameConst.GameplayRule_MenuName, order = GameConst.GameplayRule_Order)]
public class GameplayRule : ScriptableObject
{
    public float TimeSpawnEnemy;

    [Header("Value Setting")]
    public float expRate;

    public List<MonsterCharacterEntity> Monsters;
    public List<MonsterCharacterEntity> MiniBoss;
    public List<MonsterCharacterEntity> BigBoss;
}
