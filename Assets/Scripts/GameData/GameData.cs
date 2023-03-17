using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = GameConst.GameplayData_MenuName, fileName = GameConst.GameplayData_FileName, order = GameConst.GameplayData_Order)]
public class GameData : ScriptableObject
{
    public List<Item> items;
}
