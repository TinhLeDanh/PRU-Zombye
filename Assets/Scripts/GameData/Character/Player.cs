using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Player_FileName, menuName = GameConst.Player_MenuName, order = GameConst.Player_Order)]
public class Player : Character
{
    [CanBeNull] public Ring currentRing;
    [CanBeNull] public Gloves currentGloves;
    [CanBeNull] public Armor currentArmor;
    [CanBeNull] public Pant currentPant;
    [CanBeNull] public Shoes currentShoes;

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
    }

    public void OnSaveGame() {

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        var stringData = "{ \"Name\":\"" + Name+ "\",";
        stringData += "\"health\":\"" + health + "\",";
        stringData += "\"gold\":\"" + gold + "\",";
        stringData += "\"movementSpeed\":\"" + movementSpeed + "\",";
        stringData += "\"currentWeapon\":\"" + currentWeapon.name + "\",";
        stringData += "\"currentRing\":\"" + currentRing.name + "\",";
        stringData += "\"currentGloves\":\"" + currentGloves.name + "\",";
        stringData += "\"currentArmor\":\"" + currentArmor.name + "\",";
        stringData += "\"currentShoes\":\"" + currentShoes.name + "\",";
        var listHave = items;
        stringData += "\"items\":[";
        for(var i =0;i< listHave.Length;i++)
        {
            stringData += listHave[i].ToJson() ;
            if (i== listHave.Length -1)
            {
            }
            else {
                stringData += ",";
            }
        }
        stringData += "]}";
        string path = Application.dataPath + "/Cache/savedata.json";
        File.WriteAllText(path, stringData);
    }


}
