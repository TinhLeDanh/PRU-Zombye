using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Monster_FileName, menuName = GameConst.Monster_MenuName, order = GameConst.Monster_Order)]
public class Monster : Character
{
    [Header("Reward")] 
    public int exp;
    public float expRate;
    public float dropItemRate = .1f;
    public float dropGoldRate = .5f;
}
