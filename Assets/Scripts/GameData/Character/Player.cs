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

    public override int GetDamage()
    {
        int value = 0;
        if (currentWeapon != null)
        {
            value += currentWeapon.damage;
        }
        if (currentArmor != null)
        {
            value += currentArmor.damage;
        }
        if(currentPant != null)
        {
            value += currentPant.damage;
        }
        if(currentShoes != null)
        {
            value += currentShoes.damage;
        }
        if(currentRing != null)
        {
            value += currentRing.damage;
        }
        return value;
    }

    public override int GetArmor()
    {
        int value = 0;
        if (currentWeapon != null)
        {
            value += currentWeapon.armor;
        }
        if (currentArmor != null)
        {
            value += currentArmor.armor;
        }
        if (currentPant != null)
        {
            value += currentPant.armor;
        }
        if (currentShoes != null)
        {
            value += currentShoes.armor;
        }
        if (currentRing != null)
        {
            value += currentRing.armor;
        }
        return value;
    }

    public override int GetHealth()
    {
        int value = health;
        if (currentWeapon != null)
        {
            value += currentWeapon.health;
        }
        if (currentArmor != null)
        {
            value += currentArmor.health;
        }
        if (currentPant != null)
        {
            value += currentPant.health;
        }
        if (currentShoes != null)
        {
            value += currentShoes.health;
        }
        if (currentRing != null)
        {
            value += currentRing.health;
        }
        return value;
    }

    public override float GetSpeed()
    {
        float value = movementSpeed;
        if (currentWeapon != null)
        {
            value += currentWeapon.speed;
        }
        if (currentArmor != null)
        {
            value += currentArmor.speed;
        }
        if (currentPant != null)
        {
            value += currentPant.speed;
        }
        if (currentShoes != null)
        {
            value += currentShoes.speed;
        }
        if (currentRing != null)
        {
            value += currentRing.speed;
        }
        return value;
    }

    public override float GetCritRate()
    {
        float value = 0;
        if (currentWeapon != null)
        {
            value += currentWeapon.critRate;
        }
        if (currentArmor != null)
        {
            value += currentArmor.critRate;
        }
        if (currentPant != null)
        {
            value += currentPant.critRate;
        }
        if (currentShoes != null)
        {
            value += currentShoes.critRate;
        }
        if (currentRing != null)
        {
            value += currentRing.critRate;
        }
        return value;
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
    }

    public void OnSaveGame()
    {

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        var stringData = "{ \"Name\":\"" + Name + "\",";
        stringData += "\"health\":\"" + health + "\",";
        stringData += "\"gold\":\"" + gold + "\",";
        stringData += "\"movementSpeed\":\"" + movementSpeed + "\",";
        stringData += "\"currentWeapon\":\"" + currentWeapon?.name + "\",";
        stringData += "\"currentRing\":\"" + currentRing?.name + "\",";
        stringData += "\"currentGloves\":\"" + currentGloves?.name + "\",";
        stringData += "\"currentArmor\":\"" + currentArmor?.name + "\",";
        stringData += "\"currentShoes\":\"" + currentShoes?.name + "\",";
        var listHave = items;
        stringData += "\"items\":[";
        for (var i = 0; i < listHave.Length; i++)
        {
            stringData += listHave[i].ToJson();
            if (i == listHave.Length - 1)
            {
            }
            else
            {
                stringData += ",";
            }
        }
        stringData += "]}";
        string path = Application.dataPath + "/Cache/savedata.json";
        File.WriteAllText(path, stringData);
    }


}
