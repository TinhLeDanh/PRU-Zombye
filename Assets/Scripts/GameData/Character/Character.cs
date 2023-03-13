using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : BaseGameData
{
    public string Name;
    public int health;
    public float movementSpeed;
    public Weapon currentWeapon;
    public Item[] items;
}
