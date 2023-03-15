using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject container;

    public GameObject itemBox;

    public int heightOneRow;

    // Start is called before the first frame update
    void Start()
    {
        var listItem = LoadEquipment.instance.playerData.items;
        var height = 0;
        if (listItem.Length % 3 > 0)
        {
            height = heightOneRow * ((listItem.Length / 3) + 1);
        }
        else
        {
            height = heightOneRow * (listItem.Length / 3);
        }

        var index = 0;
        foreach (var item in listItem)
        {
            index++;
            GameObject obj = Instantiate(itemBox, Vector3.zero, Quaternion.identity);
            ClickItem clickItem = obj.GetComponent<ClickItem>();
            clickItem.img.sprite = item.icon;
            clickItem.textLv.text = "Lv." + item.level;
            clickItem.indexItem = index;
            obj.transform.parent = container.transform;
            if (heightOneRow > 250)
            {
                obj.transform.localScale = new Vector3(1.8f, 1.8f, 1);
            }
            else
            {
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        Destroy(itemBox);
        setHeight(height);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void setHeight(int newHeight)
    {
        Transform transform = container.transform;
        RectTransform rectTransform = container.GetComponent<RectTransform>();

        Vector2 currentPivot = rectTransform.pivot;
        Vector2 currentSizeDelta = rectTransform.sizeDelta;

        rectTransform.pivot = new Vector3(currentPivot.x, 1f, 0f);

        rectTransform.sizeDelta = new Vector2(currentSizeDelta.x, newHeight);
    }
}