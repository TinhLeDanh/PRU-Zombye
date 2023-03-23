using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Monster_FileName, menuName = GameConst.Monster_MenuName, order = GameConst.Monster_Order)]
public class Monster : Character
{
    [Header("Reward")] 
    public int exp;
    public float expRate;
    public float dropItemRate = .1f;
    public float dropGoldRate = .5f;

    public override int GetDamage()
    {
        int value = 0;
        if (currentWeapon != null)
        {
            value += currentWeapon.damage;
        }
        return value;
    }

    public override int GetArmor()
    {
        int value = 0;
        if (currentWeapon != null)
        {
            value += currentWeapon.armor;
        }
        return value;
    }

    public override int GetHealth()
    {
        int value = health;
        if (currentWeapon != null)
        {
            value += currentWeapon.health;
        }
        return value;
    }

    public override float GetSpeed()
    {
        float value = movementSpeed;
        if (currentWeapon != null)
        {
            value += currentWeapon.speed;
        }
        return value;
    }

    public override float GetCritRate()
    {
        float value = 0;
        if (currentWeapon != null)
        {
            value += currentWeapon.critRate;
        }
        return value;
    }
}
