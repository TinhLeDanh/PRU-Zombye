using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    // public 
    public Image img;
    public TMP_Text textLv;
    public int indexItem;

    public Popup popup;

    // Start is called before the first frame update
    void Start()
    {
        img = img.GetComponent<Image>();
        // LoadEquipment.instance.playerData.items;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickItem()
    {
        popup.indexInInventory = indexItem-1;
        popup.ChangeDataPopup();
        Debug.Log("ttt " + indexItem);
    }
}