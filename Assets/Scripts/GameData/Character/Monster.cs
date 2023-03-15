using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Monster_FileName, menuName = GameConst.Monster_MenuName, order = GameConst.Monster_Order)]
public class Monster : Character
{
    [Header("Reward")]
    public int exp;
    public float expRate;
}
