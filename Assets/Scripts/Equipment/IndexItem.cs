using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndexItem : MonoBehaviour
{
    public StatusIndexItem statusIndexItem;
    public TMP_Text indexItem;
    // Start is called before the first frame update
    void Start()
    {
        //switch (statusIndexItem)
        //{
        //    case StatusIndexItem.Armor:
        //        if(LoadEquipment.instance.playerData.currentArmor)
        //            indexItem.text = LoadEquipment.instance.playerData.currentArmor.armor.ToString();
        //        break;
        //    case StatusIndexItem.Speed:
        //        if(LoadEquipment.instance.playerData.currentShoes)
        //            indexItem.text = LoadEquipment.instance.playerData.currentShoes.speed.ToString();
        //        break;
        //    case StatusIndexItem.Hp:
        //        if(LoadEquipment.instance.playerData.currentPant)
        //            indexItem.text = LoadEquipment.instance.playerData.currentPant.hp.ToString();
        //        break;
        //    case StatusIndexItem.CriticalRate:
        //        if(LoadEquipment.instance.playerData.currentGloves)
        //            indexItem.text = LoadEquipment.instance.playerData.currentGloves.criticalRate+"%";
        //        break;
        //    case StatusIndexItem.Damage:
        //        if(LoadEquipment.instance.playerData.currentWeapon&&LoadEquipment.instance.playerData.currentRing)
        //            indexItem.text = (LoadEquipment.instance.playerData.currentWeapon.damage
        //                          +LoadEquipment.instance.playerData.currentRing.damage).ToString();
        //        break;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum StatusIndexItem
{
    Damage,
    Speed,
    Hp,
    CriticalRate,
    Armor
}
