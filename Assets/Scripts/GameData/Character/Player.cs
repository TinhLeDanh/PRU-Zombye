using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Player_FileName, menuName = GameConst.Player_MenuName, order = GameConst.Player_Order)]
public class Player : Character
{
    [CanBeNull] public Ring currentRing;
    [CanBeNull] public Gloves currentGloves;
    [CanBeNull] public Armor currentArmor;
    [CanBeNull] public Pant currentPant;
    [CanBeNull] public Shoes currentShoes;
}
