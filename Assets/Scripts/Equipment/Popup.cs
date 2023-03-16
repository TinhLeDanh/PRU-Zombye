using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    // public static Popup instance;

    public Image img;
    public TMP_Text textLv;
    public int indexInInventory { get; set; }
    public static Popup instance;

    public Image iconItemAdd1;
    public TMP_Text lvAdd1;
    public Image iconItemAdd2;
    public TMP_Text lvAdd2;
    public Image iconItemAdd3;
    public TMP_Text lvAdd3;

    public Image iconOutput;
    public TMP_Text lvOuput;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
    }

    public void ChangeDataPopup()
    {
        var item = LoadEquipment.instance.playerData.items[indexInInventory];
        textLv.text = "Lv." + item.level;
        img.sprite = item.icon;
    }

    public void Add()
    {
        indexAdd = indexInInventory;
        var item = LoadEquipment.instance.playerData.items[indexAdd];
        if (item.level < 5)
        {
            var listItem = LoadEquipment.instance.playerData.items
                .Where(x => x.level == item.level && x.itemName == item.itemName)
                .ToList();
            if (listItem.Count >= 3)
            {
                statusUnify = true;
                ChangeUnify(item.icon, item.level);
            }
        }
    }

    private bool statusUnify;
    private int indexAdd;
    public void UnifyItem()
    {
        if (statusUnify)
        {
            var item = LoadEquipment.instance.playerData.items[indexAdd];
            var listAllItem = LoadEquipment.instance.playerData.items;
            var count = 0;
            Item[] newListItems = new Item[] { };
            foreach (var i in listAllItem)
            {
                if (i.level == item.level && i.itemName == item.itemName && count < 3)
                {
                    count++;
                }
                else
                {
                    Array.Resize(ref newListItems, newListItems.Length + 1);
                    newListItems[newListItems.Length - 1] = i;
                }
            }

            Array.Resize(ref newListItems, newListItems.Length + 1); // Tăng kích thước mảng lên 1
            Array.Copy(newListItems, 0, newListItems, 1, newListItems.Length - 1); // Dời các phần tử sang phải một bậc
            item.level++;
            newListItems[0] = item;
            LoadEquipment.instance.playerData.items = newListItems;
            // ChangeUnify(null, 0);
            SceneManager.LoadSceneAsync("ItemMerge");
        }
    }

    private void ChangeUnify([CanBeNull] Sprite icon, int level)
    {
        iconItemAdd1.sprite = icon;
        iconItemAdd2.sprite = icon;
        iconItemAdd3.sprite = icon;
        iconOutput.sprite = icon;
        lvAdd1.text = "Lv." + level;
        lvAdd2.text = "Lv." + level;
        lvAdd3.text = "Lv." + level;
        lvOuput.text = "Lv." + (level + 1);
    }

    public void RemoveItem()
    {
        var list = LoadEquipment.instance.playerData.items;
        int indexToRemove = indexInInventory;
        Array.Copy(list, 
            indexToRemove + 1, list, 
            indexToRemove, list.Length - indexToRemove - 1); 
        Array.Resize(ref list, list.Length - 1);
        LoadEquipment.instance.playerData.items = list;
        SceneManager.LoadSceneAsync("Equipment");
    }
    public Sprite icon;
    public int level;
    public string description;
    public ItemType itemType;
    public ItemName itemName;
    public void EquipmentItem()
    {
        var itemAdd = LoadEquipment.instance.playerData.items[indexInInventory];
        var weaponMain =  LoadEquipment.instance.playerData.currentWeapon;
        Item i = ScriptableObject.CreateInstance<Item>();
    }
}