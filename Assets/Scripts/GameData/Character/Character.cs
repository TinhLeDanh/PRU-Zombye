using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Character : BaseGameData
{
    public string Name;
    public int health;
    public int coin;
    public float movementSpeed;
    [CanBeNull] public Weapon currentWeapon;

    public Item[] items;
}
