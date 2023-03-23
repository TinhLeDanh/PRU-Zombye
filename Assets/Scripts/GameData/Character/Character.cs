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
    [CanBeNull] public Weapon currentWeapon;

    public Item[] items;

    public virtual int GetDamage()
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
