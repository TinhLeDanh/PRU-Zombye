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
        switch (statusIndexItem)
        {
            case StatusIndexItem.Armor:
                indexItem.text = LoadEquipment.instance.playerData.GetArmor().ToString();
                break;
            case StatusIndexItem.Speed:
                indexItem.text = LoadEquipment.instance.playerData.GetSpeed()+"";
                break;
            case StatusIndexItem.Hp:
                indexItem.text = LoadEquipment.instance.playerData.GetHealth().ToString();
                break;
            case StatusIndexItem.CriticalRate:
                if(LoadEquipment.instance.playerData.currentGloves)
                        indexItem.text = LoadEquipment.instance.playerData.currentGloves.critRate+"%";
                break;
            case StatusIndexItem.Damage:
                indexItem.text = LoadEquipment.instance.playerData.GetDamage().ToString();
                break;
        }
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
