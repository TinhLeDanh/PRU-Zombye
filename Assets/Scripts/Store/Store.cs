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
}