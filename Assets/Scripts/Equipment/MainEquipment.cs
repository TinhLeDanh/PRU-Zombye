using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainEquipment : MonoBehaviour
{
    public Image image;

    public TMP_Text textLv;
    public ItemType itemName;

    // Start is called before the first frame update
    void Start()
    {
        image = image.GetComponent<Image>();
        switch (itemName)
        {
            case ItemType.Armor:
                image.sprite = LoadEquipment.instance.playerData.currentArmor.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentArmor.level;
                break;
            case ItemType.Gloves:
                image.sprite = LoadEquipment.instance.playerData.currentGloves.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentGloves.level;
                break;
            case ItemType.Pant:
                image.sprite = LoadEquipment.instance.playerData.currentPant.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentPant.level;
                break;
            case ItemType.Ring:
                image.sprite = LoadEquipment.instance.playerData.currentRing.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentRing.level;
                break;
            case ItemType.Shoes:
                image.sprite = LoadEquipment.instance.playerData.currentShoes.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentShoes.level;
                break;
            case ItemType.Weapon:
                image.sprite = LoadEquipment.instance.playerData.currentWeapon.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentWeapon.level;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}