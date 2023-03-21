using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Store : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pannelDefault;
    public GameObject pannelPopUp;
    public Player playerData;

    public void onClickOpenBoxGold()
    {
        Debug.Log("onClickOpenBoxGold");
        pannelDefault.SetActive(false);
        pannelPopUp.SetActive(true);

        // save game data
        var stringData = "Name:" + playerData.Name.ToString() + "/";
        stringData += "Health," + playerData.health + "/";
        stringData += "Movement_speed," + playerData.movementSpeed + "/";
        stringData += "Current_weapon," + playerData.currentWeapon.name + "/";
        stringData += "Current_ring," + playerData.currentRing.name + "/";
        stringData += "Current_gloves," + playerData.currentGloves.name + "/";
        stringData += "Current_armor," + playerData.currentArmor.name + "/";
        stringData += "Current_shoes," + playerData.currentShoes.name + "/";
        var listHave = playerData.items;
        stringData += "items";
        foreach (var item in listHave) {
            stringData += "," + item.name;
        }
        stringData += "/";
        string path = Application.dataPath + "/Cache/savedata.txt";
        File.WriteAllText(path, stringData);
    }

    public void onClickOkay()
    {
        pannelDefault.SetActive(true);
        pannelPopUp.SetActive(false);


    }

    public Item RandomItem(int salt) {
        // salt 0  rương vàng  -  80% xám 20% vàng - 100 coin
        // salt 1 rương kim cương -  50% xám 30% vàng 20% tím - 150 coin

        int typeItem = Random.Range(0, 5); //0 - 4
        int levelItem = 0; //0 - 2
        int pendingRandom = Random.Range(0, 9);
        switch (salt) {
            case 0:
                if (pendingRandom >= 8)
                {
                    levelItem = 1;
                }
                else {
                    levelItem = 0;
                }
                break;
            case 1:
                if (pendingRandom <= 4)
                {
                    levelItem = 0;
                }
                else if (pendingRandom <= 7)
                {
                    levelItem = 1;
                }
                else {
                    levelItem = 2;
                }
                break;
        }

        int indexItem = levelItem + typeItem * 3;

        Item item = new Item();

        switch (indexItem) {
            case (int)ItemName.IronArmor:
                item.itemName = ItemName.IronArmor;
                break;
            case (int)ItemName.MachineArmor:
                item.itemName = ItemName.MachineArmor;
                break;
            case (int)ItemName.TitanArmor:
                item.itemName = ItemName.TitanArmor;
                break;
            case (int)ItemName.IronGloves:
                item.itemName = ItemName.IronGloves;
                break;
            case (int)ItemName.MachineGloves:
                item.itemName = ItemName.MachineGloves;
                break;
            case (int)ItemName.TitaniumGloves:
                item.itemName = ItemName.TitaniumGloves;
                break;
            case (int)ItemName.IronPant:
                item.itemName = ItemName.IronPant;
                break;
            case (int)ItemName.MachinePant:
                item.itemName = ItemName.MachinePant;
                break;
            case (int)ItemName.PantTitan:
                item.itemName = ItemName.PantTitan;
                break;
            case (int)ItemName.DarknessRing:
                item.itemName = ItemName.DarknessRing;
                break;
            case (int)ItemName.DestructionRing:
                item.itemName = ItemName.DestructionRing;
                break;
            case (int)ItemName.DevilRing:
                item.itemName = ItemName.DevilRing;
                break;
            case (int)ItemName.IronShoes:
                item.itemName = ItemName.IronShoes;
                break;
            case (int)ItemName.MachineShoes:
                item.itemName = ItemName.MachineShoes;
                break;
            case (int)ItemName.TitanShoes:
                item.itemName = ItemName.TitanShoes;
                break;
            case (int)ItemName.Brick:
                item.itemName = ItemName.Brick;
                break;
            case (int)ItemName.PoisonBottle:
                item.itemName = ItemName.PoisonBottle;
                break;
            case (int)ItemName.WoodenRuler:
                item.itemName = ItemName.WoodenRuler;
                break;
        }

        return item;
    }
}
