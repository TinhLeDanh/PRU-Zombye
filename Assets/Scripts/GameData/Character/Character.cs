using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ScriptableObject
{
    public string Name;
    public float movementSpeed;
    public Weapon currentWeapon;
    public Weapon[] weapons;
}
