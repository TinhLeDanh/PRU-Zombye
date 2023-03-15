using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainEquipment : MonoBehaviour
{
    public Image image;

    public TMP_Text textLv;
    public EquipmentName equipmentName;

    // Start is called before the first frame update
    void Start()
    {
        image = image.GetComponent<Image>();
        switch (equipmentName)
        {
            case EquipmentName.Armor:
                image.sprite = LoadEquipment.instance.playerData.currentArmor.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentArmor.level;
                break;
            case EquipmentName.Gloves:
                image.sprite = LoadEquipment.instance.playerData.currentGloves.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentGloves.level;
                break;
            case EquipmentName.Pant:
                image.sprite = LoadEquipment.instance.playerData.currentPant.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentPant.level;
                break;
            case EquipmentName.Ring:
                image.sprite = LoadEquipment.instance.playerData.currentRing.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentRing.level;
                break;
            case EquipmentName.Shoes:
                image.sprite = LoadEquipment.instance.playerData.currentShoes.icon;
                textLv.text = "Lv." + LoadEquipment.instance.playerData.currentShoes.level;
                break;
            case EquipmentName.Weapon:
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

public enum EquipmentName
{
    Armor, //áo giáp
    Gloves, // Găng tay
    Pant, // quần
    Ring, //Nhẫn
    Shoes, //Đôi giày
    Weapon, //vũ khí
}