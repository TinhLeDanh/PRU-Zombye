using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Shoes_FileName, menuName = GameConst.Shoes_MenuName, order = GameConst.Shoes_Order)]
public class Shoes : Item
{
    public int speed;
}
