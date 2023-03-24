using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Character : BaseGameData
{
    public string Name;
    public int health;
    public int gold;
    public float movementSpeed;

    [Header("Level setting")]
    public float inceraseHpEachLevel;
    public float inceraseDamageEachLevel;
    public float inceraseArmorEachLevel;

    [CanBeNull] public Weapon currentWeapon;

    public Item[] items;

    public virtual int GetDamage()
    {
        return 0;
    }

    public int GetDamage(int level)
    {
        return (int)(GetDamage() + GetDamage() * inceraseDamageEachLevel * level);
    }

    public int GetHealth(int level)
    {
        return (int)(GetHealth() + GetHealth() * inceraseHpEachLevel * level);
    }

    public int GetHealth(int level, int currentMaxHealth)
    {
        return (int)(GetHealth() + currentMaxHealth * inceraseHpEachLevel * level);
    }

    public int GetArmor(int level)
    {
        return (int)(GetArmor() + GetArmor() * inceraseArmorEachLevel * level);
    }

    public virtual float GetRegenRate()
    {
        return 0;
    }


    public virtual int GetArmor()
    {
        return 0;

    }

    public virtual int GetHealth()
    {
        return 0;

    }

    public virtual float GetSpeed()
    {
        return 0;

    }

    public virtual float GetCritRate()
    {
        return 0;

    }
}
