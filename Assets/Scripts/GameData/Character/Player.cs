using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Player_FileName, menuName = GameConst.Player_MenuName, order = GameConst.Player_Order)]
public class Player : Character
{
    public Ring currentRing;
    public Gloves currentGloves;
    public Armor currentArmor;
    public Pant currentPant;
    public Shoes currentShoes;
}
