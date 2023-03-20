using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : BaseGameData
{
    public Sprite icon;
    public int level;
    public string description;
    public ItemType itemType;
    public ItemName itemName;
}
public enum ItemType
{
    Armor, //áo giáp
    Gloves, // Găng tay
    Pant, // quần
    Ring, //Nhẫn
    Shoes, //Đôi giày
    Weapon, //vũ khí
}
public enum ItemName
{
    //Armor áo giáp
    IronArmor,
    MachineArmor,
    TitanArmor,
    // Gloves Găng tay
    IronGloves,
    MachineGloves,
    TitaniumGloves,
    // Pant quần
    IronPant,
    MachinePant,
    PantTitan,
    // Ring Nhẫn
    DarknessRing,
    DestructionRing,
    DevilRing,
    // Shoes Đôi giày
    IronShoes,
    MachineShoes,
    TitanShoes,
    // Weapon vũ khí
    Brick,
    PoisonBottle,
    WoodenRuler,
}