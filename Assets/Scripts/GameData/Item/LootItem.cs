using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.LootItem_MenuName, fileName = GameConst.LootItem_FileName, order = GameConst.LootItem_Order)]
public class LootItem : Item
{
    public SpriteRenderer icon;
}
