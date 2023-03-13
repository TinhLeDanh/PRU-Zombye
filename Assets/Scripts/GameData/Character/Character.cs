using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ScriptableObject
{
    public string Name;
    public float movementSpeed;
    public Weapon currentWeapon;
    public Ring currentRing;
    public Gloves currentGloves;
    public Armor currentArmor;
    public Pant currentPant;
    public Shoes currentShoes;
    public Item[] items;
}
