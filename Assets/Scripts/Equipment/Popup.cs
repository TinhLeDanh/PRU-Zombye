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

    public Player playerAll;

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
            Array.Copy(newListItems, 0, newListItems, 1, newListItems.Length - 1);
            var level = item.level+1;
            var newItem = playerAll.items.FirstOrDefault(x => x.level == level && x.itemName == item.itemName);
            newListItems[0] = newItem;
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
    public void EquipmentItem()
    {
        var list = LoadEquipment.instance.playerData.items;
        var itemAdd = LoadEquipment.instance.playerData.items[indexInInventory];
        if (itemAdd is Weapon weapon)
        {
            var weaponMain =  LoadEquipment.instance.playerData.currentWeapon;
            LoadEquipment.instance.playerData.currentWeapon = weapon;
            
            if (weaponMain is not null)
            {
                LoadEquipment.instance.playerData.items[indexInInventory] = weaponMain;
            }
            else
            {
                Array.Copy(list, 
                    indexInInventory + 1, list, 
                    indexInInventory, list.Length - indexInInventory - 1); 
                Array.Resize(ref list, list.Length - 1);
                LoadEquipment.instance.playerData.items = list;
            }
        }
        if (itemAdd is Armor armor)
        {
            var armorMain =  LoadEquipment.instance.playerData.currentArmor;
            LoadEquipment.instance.playerData.currentArmor = armor;
            
            if (armorMain is not null)
            {
                LoadEquipment.instance.playerData.items[indexInInventory] = armorMain;
            }else
            {
                Array.Copy(list, 
                    indexInInventory + 1, list, 
                    indexInInventory, list.Length - indexInInventory - 1); 
                Array.Resize(ref list, list.Length - 1);
                LoadEquipment.instance.playerData.items = list;
            }
        }
        if (itemAdd is Gloves gloves)
        {
            var glovesMain =  LoadEquipment.instance.playerData.currentGloves;
            LoadEquipment.instance.playerData.currentGloves = gloves;
            
            if (glovesMain is not null)
            {
                LoadEquipment.instance.playerData.items[indexInInventory] = glovesMain;
            }else
            {
                Array.Copy(list, 
                    indexInInventory + 1, list, 
                    indexInInventory, list.Length - indexInInventory - 1); 
                Array.Resize(ref list, list.Length - 1);
                LoadEquipment.instance.playerData.items = list;
            }
        }
        if (itemAdd is Pant pant)
        {
            var glovesMain =  LoadEquipment.instance.playerData.currentPant;
            LoadEquipment.instance.playerData.currentPant = pant;
            
            if (glovesMain is not null)
            {
                LoadEquipment.instance.playerData.items[indexInInventory] = glovesMain;
            }else
            {
                Array.Copy(list, 
                    indexInInventory + 1, list, 
                    indexInInventory, list.Length - indexInInventory - 1); 
                Array.Resize(ref list, list.Length - 1);
                LoadEquipment.instance.playerData.items = list;
            }
        }
        if (itemAdd is Ring ring)
        {
            var ringMain =  LoadEquipment.instance.playerData.currentRing;
            LoadEquipment.instance.playerData.currentRing = ring;
            
            if (ringMain is not null)
            {
                LoadEquipment.instance.playerData.items[indexInInventory] = ringMain;
            }else
            {
                Array.Copy(list, 
                    indexInInventory + 1, list, 
                    indexInInventory, list.Length - indexInInventory - 1); 
                Array.Resize(ref list, list.Length - 1);
                LoadEquipment.instance.playerData.items = list;
            }
        }
        if (itemAdd is Shoes shoes)
        {
            var shoesMain =  LoadEquipment.instance.playerData.currentShoes;
            LoadEquipment.instance.playerData.currentShoes = shoes;
            
            if (shoesMain is not null)
            {
                LoadEquipment.instance.playerData.items[indexInInventory] = shoesMain;
            }else
            {
                Array.Copy(list, 
                    indexInInventory + 1, list, 
                    indexInInventory, list.Length - indexInInventory - 1); 
                Array.Resize(ref list, list.Length - 1);
                LoadEquipment.instance.playerData.items = list;
            }
        }
        SceneManager.LoadSceneAsync("Equipment");
    }

    public ItemType typeBtnClick;
    public void RemovedFromEquipment()
    {
        Item[] newListItems = LoadEquipment.instance.playerData.items;
        Array.Resize(ref newListItems, newListItems.Length + 1); // Tăng kích thước mảng lên 1
        Array.Copy(newListItems, 0, newListItems, 1, newListItems.Length - 1);
        switch (typeBtnClick)
        {
            case ItemType.Armor:
                newListItems[0] = LoadEquipment.instance.playerData.currentArmor;
                LoadEquipment.instance.playerData.currentArmor = null;
                break;
            case ItemType.Gloves:
                newListItems[0] = LoadEquipment.instance.playerData.currentGloves;
                LoadEquipment.instance.playerData.currentGloves = null;
                break;
            case ItemType.Pant:
                newListItems[0] = LoadEquipment.instance.playerData.currentPant;
                LoadEquipment.instance.playerData.currentPant = null;
                break;
            case ItemType.Ring:
                newListItems[0] = LoadEquipment.instance.playerData.currentRing;
                LoadEquipment.instance.playerData.currentRing = null;
                break;
            case ItemType.Shoes:
                newListItems[0] = LoadEquipment.instance.playerData.currentShoes;
                LoadEquipment.instance.playerData.currentShoes = null;
                break;
            case ItemType.Weapon:
                newListItems[0] = LoadEquipment.instance.playerData.currentWeapon;
                LoadEquipment.instance.playerData.currentWeapon = null;
                break;
        }
        LoadEquipment.instance.playerData.items = newListItems;
        SceneManager.LoadSceneAsync("Equipment");
    }

    public void ClickArmor()
    {
        typeBtnClick = ItemType.Armor;
    }
    public void ClickGloves()
    {
        typeBtnClick = ItemType.Gloves;
    }
    public void ClickPant()
    {
        typeBtnClick = ItemType.Pant;
    }
    public void ClickRing()
    {
        typeBtnClick = ItemType.Ring;
    }
    public void ClickShoes()
    {
        typeBtnClick = ItemType.Shoes;
    }
    public void ClickWeapon()
    {
        typeBtnClick = ItemType.Weapon;
    }
    
    
}